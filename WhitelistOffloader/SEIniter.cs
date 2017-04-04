using Sandbox;
using Sandbox.Engine.Utils;
using Sandbox.Game;
using SpaceEngineers.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VRage.FileSystem;
using VRage.Utils;

namespace SEIniter
{
    public static class SEIniter
    {
        private static MySandboxGame m_spacegame = null;
        private static MyCommonProgramStartup m_startup;
        private static Sandbox.MySteamService m_steamService;
        const uint AppId_SE = 244850;      // MUST MATCH SE
        static bool inited = false;

        static SEIniter()
        {
            // Steam API doesn't initialize correctly if it can't find steam_appid.txt
            if (!File.Exists("steam_appid.txt"))
                Directory.SetCurrentDirectory(Path.GetDirectoryName(Path.GetDirectoryName(typeof(VRage.FastResourceLock).Assembly.Location)));
            InitSandbox();
            // Init ModAPI
            var initmethod = typeof(MySandboxGame).GetMethod("InitModAPI", BindingFlags.Instance | BindingFlags.NonPublic);
            MyDebug.AssertDebug(initmethod != null);

            if (initmethod != null)
            {
                var parameters = initmethod.GetParameters();
                MyDebug.AssertDebug(parameters.Count() == 0);

                if (!(parameters.Count() == 0))
                    initmethod = null;
            }

            if (initmethod != null)
                initmethod.Invoke(m_spacegame, null);
            else
                throw new Exception(string.Format("WARNING: Could not reflect '{0}', some functions may not work", "InitModAPI"));
            inited = true;
        }
        public static bool Init()
        {
            return inited;
        }
        private static void InitSandbox()
        {
            MyFakes.ENABLE_INFINARIO = false;

            if (m_spacegame != null)
                m_spacegame.Exit();

            SpaceEngineersGame.SetupBasicGameInfo();
            m_startup = new MyCommonProgramStartup(new string[] { });

            var appDataPath = m_startup.GetAppDataPath();
            MyInitializer.InvokeBeforeRun(AppId_SE, MyPerGameSettings.BasicGameInfo.ApplicationName + "ModTool", appDataPath);
            MyInitializer.InitCheckSum();

            if (!m_startup.Check64Bit()) return;

            m_steamService = new MySteamService(true, 298740);
            SpaceEngineersGame.SetupPerGameSettings();


            if (System.Diagnostics.Debugger.IsAttached)
                m_startup.CheckSteamRunning(m_steamService);        // Just give the warning message box when debugging, ignore for release

            VRageGameServices services = new VRageGameServices(m_steamService);

            /*if (!MySandboxGame.IsDedicated)
                MyFileSystem.InitUserSpecific(m_steamService.UserId.ToString());*/

            try
            {
                // NOTE: an assert may be thrown in debug, about missing Tutorials.sbx. Ignore it.
                m_spacegame = new SpaceEngineersGame(services, null);

                // Initializing the workshop means the categories are available
                var initWorkshopMethod = typeof(SpaceEngineersGame).GetMethod("InitSteamWorkshop", BindingFlags.NonPublic | BindingFlags.Instance);
                MyDebug.AssertDebug(initWorkshopMethod != null);

                if (initWorkshopMethod != null)
                {
                    var parameters = initWorkshopMethod.GetParameters();
                    MyDebug.AssertDebug(parameters.Count() == 0);
                }

                if (initWorkshopMethod != null)
                    initWorkshopMethod.Invoke(m_spacegame, null);
                else
                    throw new Exception(string.Format("WARNING: Could not reflect '{0}', some functions may not work", "InitSteamWorkshop"));
            }
            catch (Exception ex)
            {
                throw new Exception("An exception occured, ignoring: " + ex.Message);
            }
        }
    }
}
