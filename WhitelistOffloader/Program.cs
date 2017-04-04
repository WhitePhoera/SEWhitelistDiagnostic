using HtmlAgilityPack;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using VRage.Scripting;

namespace WhitelistOffloader
{
    class Program
    {
        const string ExtractArg = "--extract:";
        const string KeepArg = "--keep";
        const string VerboseArg = "--verbose";
        const string SaveArg = "--save";
        const string DontValidateArg = "--dont-validate";

        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> modData = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> igsData = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> igsbData = new Dictionary<string, HashSet<string>>();
            string extract = args.FirstOrDefault(a => a.StartsWith(ExtractArg));
            bool keep = args.FirstOrDefault(a => a == KeepArg) != null;
            bool verbose = args.FirstOrDefault(a => a == VerboseArg) != null;
            bool save = args.FirstOrDefault(a => a == SaveArg) != null;
            bool dontValidate = args.FirstOrDefault(a => a == DontValidateArg) != null;
            if (extract == null)
            {
                if (!keep && Directory.Exists("tmp"))
                {
                    Console.WriteLine("Cleanup from old run.");
                    Directory.Delete("tmp", true);
                }
                Directory.CreateDirectory("tmp");
                if (!keep || !File.Exists("tmp/steamcmd.exe"))
                    File.WriteAllBytes("tmp/steamcmd.exe", Resource1.steamcmd);
                foreach (var branch in GetBranches())
                {
                    var start = DateTime.Now;
                    try
                    {
                        Console.WriteLine($"Starting processing branch: {branch}.");
                        Directory.CreateDirectory($"tmp/SE/{branch}");
                        Console.WriteLine($"SteamCMD return code: {RunSteamCmd(branch, verbose, dontValidate)}.");
                        Console.WriteLine($"Whitelist collector return code: {RunCollector(branch, verbose)}");
                        if (!keep)
                            Directory.Delete($"tmp/SE/{branch}", true);
                        modData[branch] = new HashSet<string>(File.ReadAllLines("mod.dat"));
                        igsData[branch] = new HashSet<string>(File.ReadAllLines("igs.dat"));
                        igsbData[branch] = new HashSet<string>(File.ReadAllLines("igsb.dat"));
                        File.Delete("mod.dat");
                        File.Delete("igs.dat");
                        File.Delete("igsb.dat");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($@"Error while processing branch: {branch}
{e}.");
                    }
                    Console.WriteLine($"End processing branch: {branch} (Time taken: {DateTime.Now - start}).");
                }
                if (!keep)
                {
                    Console.WriteLine("Cleanup.");
                    Directory.Delete("tmp", true);
                }
                else
                    Console.WriteLine("Keeping temp files.");
                if (save)
                {
                    Console.WriteLine("Offloading whitelist to files.");
                    foreach (var branch in modData.Keys)
                    {
                        File.WriteAllLines($"{branch}.mod.dat", modData[branch]);
                        File.WriteAllLines($"{branch}.igs.dat", igsData[branch]);
                    }
                }
                Console.WriteLine("Fixing assembly changes.");
                HandleAssemblyChanges(modData);
                HandleAssemblyChanges(igsData);
                FormCsFile("ModData", modData, modData.ToDictionary(m=>m.Key,m=>new HashSet<string>()));
                FormCsFile("IgsData", igsData, igsbData);
            }
            else
            {
                CollectWhitelist(extract.Substring(ExtractArg.Length));
            }
        }
        static void FormCsFile(string type, Dictionary<string, HashSet<string>> data,Dictionary<string, HashSet<string>> bdata)
        {
            var common = new HashSet<string>();
            foreach (var entry in data.SelectMany(w => w.Value))
            {
                if (data.Values.All(w => w.Contains(entry)))
                    common.Add(entry);
            }
            var commonB = new HashSet<string>();
            foreach (var entry in bdata.SelectMany(w => w.Value))
            {
                if (bdata.Values.All(w => w.Contains(entry)))
                    commonB.Add(entry);
            }
            string fn = $"{type}.cs";
            File.Delete(fn);
            using (var sw = new StreamWriter(fn))
            {
                sw.WriteLine("using System.Collections.Generic;");
                sw.WriteLine();
                sw.WriteLine($"class {type}");
                sw.WriteLine("{");
                sw.WriteLine("\tpublic static HashSet<string> Common=new HashSet<string>");
                sw.WriteLine("\t{");
                foreach (var com in common)
                    sw.WriteLine($"\t\t\"{com}\",");
                sw.WriteLine("\t};");
                sw.WriteLine("\tpublic static Dictionary<string,HashSet<string>> VersionData=new Dictionary<string,HashSet<string>>");
                sw.WriteLine("\t{");
                foreach (var ver in data)
                {
                    foreach (var com in common)
                        ver.Value.Remove(com);
                    /*if (ver.Value.Count > 0)
                    {*/
                        sw.WriteLine($"\t\t[\"{ver.Key}\"]=new HashSet<string>");
                        sw.WriteLine("\t\t{");
                        foreach (var entry in ver.Value)
                        {
                            sw.WriteLine($"\t\t\t\"{entry}\",");
                        }
                        sw.WriteLine("\t\t},");
                    //}
                }
                sw.WriteLine("\t};");
                sw.WriteLine("\tpublic static HashSet<string> CommonBlack=new HashSet<string>");
                sw.WriteLine("\t{");
                foreach (var com in commonB)
                    sw.WriteLine($"\t\t\"{com}\",");
                sw.WriteLine("\t};");
                sw.WriteLine("\tpublic static Dictionary<string,HashSet<string>> VersionBlackData=new Dictionary<string,HashSet<string>>");
                sw.WriteLine("\t{");
                foreach (var ver in bdata)
                {
                    foreach (var com in common)
                        ver.Value.Remove(com);
                    /*if (ver.Value.Count > 0)
                    {*/
                    sw.WriteLine($"\t\t[\"{ver.Key}\"]=new HashSet<string>");
                    sw.WriteLine("\t\t{");
                    foreach (var entry in ver.Value)
                    {
                        sw.WriteLine($"\t\t\t\"{entry}\",");
                    }
                    sw.WriteLine("\t\t},");
                    //}
                }
                sw.WriteLine("\t};");
                sw.WriteLine("}");
            }
        }
        static void HandleAssemblyChanges(Dictionary<string, HashSet<string>> whitelist)
        {
            var fixes = whitelist.SelectMany(w => w.Value).GroupBy(GetTypeName).Where(w => w.Distinct().Count() > 1).ToDictionary(w => w.Key, w => w.Distinct().ToList());
            if (fixes.Count > 0)
                foreach (var list in whitelist)
                {
                    var intersect = list.Value.Select(GetTypeName).Intersect(fixes.Keys).ToList();
                    foreach (var inter in intersect)
                        foreach (var fix in fixes[inter])
                            list.Value.Add(fix);
                }
        }
        static string GetTypeName(string entry)
        {
            int index = entry.LastIndexOf(',');
            if (index >= 0)
                return entry.Substring(0, index);
            return entry;
        }
        static void CollectWhitelist(string dir)
        {
            SEIniter.SEIniter.Init();
            using (var swm = new StreamWriter(Path.Combine(dir, "mod.dat")))
            using (var swi = new StreamWriter(Path.Combine(dir, "igs.dat")))
                using(var swb=new StreamWriter(Path.Combine(dir,"igsb.dat")))
            {
                foreach (var entry in MyScriptCompiler.Static.Whitelist.GetWhitelist())
                {
                    if (entry.Value.HasFlag(MyWhitelistTarget.ModApi))
                        swm.WriteLine($"{entry.Key}");
                    if (entry.Value.HasFlag(MyWhitelistTarget.Ingame))
                        swi.WriteLine($"{entry.Key}");
                }
                foreach(var entry in MyScriptCompiler.Static.Whitelist.GetBlacklistedIngameEntries())
                {
                    swb.WriteLine(entry);
                }
            }
        }

        static int RunSteamCmd(string branch, bool verbose, bool dontValidate)
        {
            string valid = "validate";
            if (dontValidate)
                valid = "";
            var beta = $"-beta {branch} ";
            if (branch == "public")
                beta = "";
            var psi = new ProcessStartInfo("tmp/steamcmd.exe",
                $"+login anonymous +force_install_dir ./SE/{branch} +app_update 298740 {beta}{valid} +quit");
            psi.UseShellExecute = false;
            psi.CreateNoWindow = !verbose;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            using (var proc = Process.Start(psi))
            {
                proc.WaitForExit();
                return proc.ExitCode;
            }
        }
        static int RunCollector(string branch, bool verbose)
        {
            File.Copy(Assembly.GetEntryAssembly().Location, $"tmp/SE/{branch}/DedicatedServer64/whitelist.exe", true);
            var psi = new ProcessStartInfo($"tmp/SE/{branch}/DedicatedServer64/whitelist.exe", $"{ExtractArg}\"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\"");
            psi.UseShellExecute = false;
            psi.CreateNoWindow = !verbose;
            psi.WorkingDirectory = $"tmp/SE/{branch}/DedicatedServer64";
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            using (var proc = Process.Start(psi))
            {
                proc.WaitForExit();
                return proc.ExitCode;
            }
        }


        static readonly string[] VersionExclusion = { "dx9-32bit" };

        static List<string> GetBranches()
        {
            var res = new List<string>();
            var loader = new HtmlWeb();
            var doc = loader.Load("https://steamdb.info/app/298740/depots/");
            foreach (var node in doc.DocumentNode.SelectNodes("//div[@id='depots']//h3[contains(text(),'Branches')]/following-sibling::table/tbody/tr/td/a"))
            {
                string name = node.InnerText.Trim();
                if (!VersionExclusion.Contains(name))
                    res.Add(name);
            }
            return res;
        }
    }
}
