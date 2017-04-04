using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEWhitelistChecker
{
    class Whitelist
    {
        public static bool IsWhitelistedV1(ISymbol symbol, HashSet<string> whitelist, HashSet<string> blacklist)
        {
            var typeSymbol = symbol as INamedTypeSymbol;
            if (typeSymbol != null)
            {
                return IsWhitelisted(typeSymbol, whitelist, blacklist, true) != TypeKeyQuantity.None;
            }
            if (IsMemberSymbol(symbol))
            {
                return IsMemberWhitelisted(symbol, whitelist, blacklist, true);
            }
            return true;
        }
        public static bool IsWhitelistedV2(ISymbol symbol, HashSet<string> whitelist, HashSet<string> blacklist)
        {
            var typeSymbol = symbol as INamedTypeSymbol;
            if (typeSymbol != null)
            {
                return IsWhitelisted(typeSymbol, whitelist, blacklist, false) != TypeKeyQuantity.None;
            }
            if (IsMemberSymbol(symbol))
            {
                return IsMemberWhitelisted(symbol, whitelist, blacklist, false);
            }
            return true;
        }
        static bool IsBlacklisted(ISymbol symbol, HashSet<string> blacklist)
        {
            if (IsMemberSymbol(symbol))
            {
                if (blacklist.Contains(GetWhitelistKey(symbol, TypeKeyQuantity.ThisOnly)))
                    return true;
                symbol = (ISymbol)symbol.ContainingType;
            }
            for (ITypeSymbol symbol1 = symbol as ITypeSymbol; symbol1 != null; symbol1 = (ITypeSymbol)symbol1.ContainingType)
            {
                if (blacklist.Contains(GetWhitelistKey(symbol1, TypeKeyQuantity.AllMembers)))
                    return true;
            }
            return false;
        }
        static bool IsMemberWhitelisted(ISymbol memberSymbol, HashSet<string> whitelist, HashSet<string> blacklist, bool allowDelegates)
        {
            if (IsBlacklisted(memberSymbol, blacklist))
                return false;
            while (true)
            {
                var result = IsWhitelisted(memberSymbol.ContainingType, whitelist, blacklist, allowDelegates);
                if (result == TypeKeyQuantity.AllMembers)
                {
                    return true;
                }

                if (whitelist.Contains(GetWhitelistKey(memberSymbol, TypeKeyQuantity.ThisOnly)))
                {
                    return true;
                }

                if (memberSymbol.IsOverride)
                {
                    memberSymbol = GetOverriddenSymbol(memberSymbol);
                    if (memberSymbol != null)
                    {
                        continue;
                    }
                }

                return false;
            }
        }
        static ISymbol GetOverriddenSymbol(ISymbol symbol)
        {
            if (!symbol.IsOverride)
                return null;
            var typeSymbol = symbol as ITypeSymbol;
            if (typeSymbol != null)
                return typeSymbol.BaseType;
            var eventSymbol = symbol as IEventSymbol;
            if (eventSymbol != null)
                return eventSymbol.OverriddenEvent;
            var propertySymbol = symbol as IPropertySymbol;
            if (propertySymbol != null)
                return propertySymbol.OverriddenProperty;
            var methodSymbol = symbol as IMethodSymbol;
            if (methodSymbol != null)
                return methodSymbol.OverriddenMethod;
            return null;
        }

        static string GetWhitelistKey(ISymbol symbol, TypeKeyQuantity quantity)
        {
            var namespaceSymbol = symbol as INamespaceSymbol;
            if (namespaceSymbol != null)
            {
                return GetWhitelistKey(namespaceSymbol, quantity);
            }
            var typeSymbol = symbol as ITypeSymbol;
            if (typeSymbol != null)
            {
                return GetWhitelistKey(typeSymbol, quantity);
            }
            var methodSymbol = symbol as IMethodSymbol;
            if (methodSymbol != null)
            {
                // Account for generic methods, we must check their definitions, not specific implementations
                if (methodSymbol.IsGenericMethod && !methodSymbol.IsDefinition)
                {
                    methodSymbol = methodSymbol.OriginalDefinition;
                    return methodSymbol.ToDisplayString(SymbolDisplayFormat.CSharpErrorMessageFormat)
                            + ", "
                           + symbol.ContainingAssembly.Name;
                }
            }

            var memberSymbol = (symbol is IEventSymbol || symbol is IFieldSymbol || symbol is IPropertySymbol || symbol is IMethodSymbol) ? symbol : null;
            if (memberSymbol == null)
            {
                throw new ArgumentException("Invalid symbol type: Expected namespace, type or type member", "symbol");
            }

            return memberSymbol.ToDisplayString(SymbolDisplayFormat.CSharpErrorMessageFormat)
                    + ", "
                   + symbol.ContainingAssembly.Name;
        }
        static string GetWhitelistKey(INamespaceSymbol symbol, TypeKeyQuantity quantity)
        {
            switch (quantity)
            {
                case TypeKeyQuantity.ThisOnly:
                    return symbol.ToDisplayString(SymbolDisplayFormat.CSharpErrorMessageFormat)
                           + ", "
                           + symbol.ContainingAssembly.Name;

                case TypeKeyQuantity.AllMembers:
                    return symbol.ToDisplayString(SymbolDisplayFormat.CSharpErrorMessageFormat)
                           + ".*, "
                           + symbol.ContainingAssembly.Name;

                default:
                    throw new ArgumentOutOfRangeException(nameof(quantity), quantity, null);
            }
        }
        static ITypeSymbol ResolveRootType(ITypeSymbol symbol)
        {
            var namedTypeSymbol = symbol as INamedTypeSymbol;
            if (namedTypeSymbol != null && namedTypeSymbol.IsGenericType && !namedTypeSymbol.IsDefinition)
            {
                symbol = namedTypeSymbol.OriginalDefinition;
                //if (symbol.SpecialType == SpecialType.System_Nullable_T)
                //    return namedTypeSymbol.TypeArguments[0];
                return symbol;
            }

            var pointerTypeSymbol = symbol as IPointerTypeSymbol;
            if (pointerTypeSymbol != null)
            {
                return pointerTypeSymbol.PointedAtType;
            }

            return symbol;
        }
        static string GetWhitelistKey(ITypeSymbol symbol, TypeKeyQuantity quantity)
        {
            symbol = ResolveRootType(symbol);

            switch (quantity)
            {
                case TypeKeyQuantity.ThisOnly:
                    return symbol.ToDisplayString(SymbolDisplayFormat.CSharpErrorMessageFormat)
                           + ", "
                           + symbol.ContainingAssembly.Name;

                case TypeKeyQuantity.AllMembers:
                    return symbol.ToDisplayString(SymbolDisplayFormat.CSharpErrorMessageFormat)
                           + "+*, "
                           + symbol.ContainingAssembly.Name;

                default:
                    throw new ArgumentOutOfRangeException("quantity", quantity, null);
            }
        }
        static TypeKeyQuantity IsWhitelisted(INamespaceSymbol namespaceSymbol, HashSet<string> whitelist)
        {
            if (whitelist.Contains(GetWhitelistKey(namespaceSymbol, TypeKeyQuantity.AllMembers)))
            {
                return TypeKeyQuantity.AllMembers;
            }
            return TypeKeyQuantity.None;
        }
        static TypeKeyQuantity IsWhitelisted(INamedTypeSymbol typeSymbol, HashSet<string> whitelist, HashSet<string> blacklist, bool allowDelegates)
        {
            // Delegates are allowed directly in checking, as they are harmless since you have to call 
            // or store something in it which is also checked.
            if (allowDelegates && IsDelegate(typeSymbol))
            {
                return TypeKeyQuantity.AllMembers;
            }
            if (IsBlacklisted(typeSymbol, blacklist))
                return TypeKeyQuantity.None;
            var result = IsWhitelisted(typeSymbol.ContainingNamespace, whitelist);
            if (result == TypeKeyQuantity.AllMembers)
            {
                return result;
            }

            if (whitelist.Contains(GetWhitelistKey(typeSymbol, TypeKeyQuantity.AllMembers)))
            {
                return TypeKeyQuantity.AllMembers;
            }

            if (whitelist.Contains(GetWhitelistKey(typeSymbol, TypeKeyQuantity.ThisOnly)))
            {
                return TypeKeyQuantity.ThisOnly;
            }

            return TypeKeyQuantity.None;
        }
        static bool IsDelegate(INamedTypeSymbol typeSymbol)
        {
            while (typeSymbol != null)
            {
                if (typeSymbol.SpecialType == SpecialType.System_Delegate || typeSymbol.SpecialType == SpecialType.System_MulticastDelegate)
                {
                    return true;
                }
                typeSymbol = typeSymbol.BaseType;
            }
            return false;
        }
        static bool IsMemberSymbol(ISymbol symbol)
        {
            return (symbol is IEventSymbol || symbol is IFieldSymbol || symbol is IPropertySymbol || symbol is IMethodSymbol);
        }
    }
}
