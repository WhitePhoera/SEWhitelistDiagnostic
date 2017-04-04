using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SEWhitelistChecker
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SEWhitelistCheckerAnalyzer : DiagnosticAnalyzer
    {
        Lazy<ImmutableArray<DiagnosticDescriptor>> initer;
        const string IdPrefix = "ProhibitedMemberRule";

        static readonly string[] UseV1Whitelist = { "1.172" };


        public SEWhitelistCheckerAnalyzer()
        {
            initer = new Lazy<ImmutableArray<DiagnosticDescriptor>>(Initializer);
        }

        private ImmutableArray<DiagnosticDescriptor> Initializer()
        {
            return ImmutableArray.Create(InitFromVersions("Mod script", "M", ModData.VersionData.Keys, ModDesc).Union(InitFromVersions("In-game script", "I", IgsData.VersionData.Keys, IgsDesc)).ToArray());
        }
        Dictionary<string, DiagnosticDescriptor> ModDesc = new Dictionary<string, DiagnosticDescriptor>();
        Dictionary<string, DiagnosticDescriptor> IgsDesc = new Dictionary<string, DiagnosticDescriptor>();


        IEnumerable<DiagnosticDescriptor> InitFromVersions(string type, string IdSuffix, IEnumerable<string> version, Dictionary<string, DiagnosticDescriptor> desc)
        {
            yield return desc[""] = new DiagnosticDescriptor($"{IdPrefix}{IdSuffix}", $"Prohibited Type Or Member({type})", $"The type or member '{{0}}' is prohibited({type})", "Whitelist", DiagnosticSeverity.Error, false);
            foreach (var vers in version)
                yield return desc[vers] = new DiagnosticDescriptor($"{IdPrefix}{IdSuffix}{vers}", $"Prohibited Type Or Member({type}, {vers})", $"The type or member '{{0}}' is prohibited({type}, {vers})", "Whitelist", DiagnosticSeverity.Error, false);
        }


        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return initer.Value; } }
        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeSymbol,
                SyntaxKind.AliasQualifiedName,
                SyntaxKind.QualifiedName,
                SyntaxKind.GenericName,
                SyntaxKind.IdentifierName);
        }
        public Func<ISymbol, HashSet<string>, HashSet<string>, bool> GetWhitelistChecker(string version)
        {
            if (UseV1Whitelist.Contains(version))
                return Whitelist.IsWhitelistedV1;
            return Whitelist.IsWhitelistedV2;
        }
        public bool IsInSource(ISymbol symbol)
        {
            for (var i = 0; i < symbol.Locations.Length; i++)
            {
                if (!symbol.Locations[i].IsInSource)
                {
                    return false;
                }
            }
            return true;
        }
        void DoCheck(SyntaxNodeAnalysisContext context, SyntaxNode node, SymbolInfo info, Dictionary<string, DiagnosticDescriptor> descs, HashSet<string> common, Dictionary<string, HashSet<string>> versioned, HashSet<string> commonBlack, Dictionary<string, HashSet<string>> versionedBlack)
        {
            var errors = new HashSet<string>();
            if (!GetWhitelistChecker("")(info.Symbol, common, commonBlack))
            {
                foreach (var vers in versioned)
                {
                    if (!GetWhitelistChecker(vers.Key)(info.Symbol, vers.Value, versionedBlack[vers.Key]))
                        errors.Add(vers.Key);
                }
                if (errors.Count == versioned.Count)
                    context.ReportDiagnostic(Diagnostic.Create(descs[""], node.GetLocation(), info.Symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)));
                else
                {
                    var loc = node.GetLocation();
                    var name = info.Symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
                    foreach (var errVer in errors)
                        context.ReportDiagnostic(Diagnostic.Create(descs[errVer], loc, name));
                }
            }
        }
        private void AnalyzeSymbol(SyntaxNodeAnalysisContext context)
        {
            var node = context.Node;
            // We'll check the qualified names on their own.
            if (IsQualifiedName(node.Parent))
            {
                //if (node.Ancestors().Any(IsQualifiedName))
                return;
            }

            var info = context.SemanticModel.GetSymbolInfo(node);
            if (info.Symbol == null)
            {
                return;
            }
            // If they wrote it, they can have it.
            if (IsInSource(info.Symbol))
            {
                return;
            }
            DoCheck(context, node, info, ModDesc, ModData.Common, ModData.VersionData, ModData.CommonBlack, ModData.VersionBlackData);
            DoCheck(context, node, info, IgsDesc, IgsData.Common, IgsData.VersionData, IgsData.CommonBlack, IgsData.VersionBlackData);
        }
        static bool IsQualifiedName(SyntaxNode arg)
        {
            switch (arg.Kind())
            {
                case SyntaxKind.QualifiedName:
                case SyntaxKind.AliasQualifiedName:
                    return true;
            }
            return false;
        }
    }
}
