using Base.Core;
using Base.Defs;
using Harmony;
using PhoenixPoint.Tactical.Entities.Abilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SelectClassTraits
{
    public class SelectClassTraits
    {
        internal static string LogPath;
        internal static string ModDirectory;
        internal static Settings Settings;
        internal static HarmonyInstance Harmony;

        public static void MainMod(Func<string, object, object> api)
        {
            //mod setup
            Harmony = HarmonyInstance.Create("Lotrick.SelectClassTraits");
            ModDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            LogPath = Path.Combine(ModDirectory, "SelectClassTraits.log");
            Settings = api("config", null) as Settings ?? new Settings();

            Logger.Initialize(LogPath, SelectClassTraits.Settings.Debug, ModDirectory, nameof(SelectClassTraits));

            Harmony.PatchAll();

            Logger.Always($"Modnix Lotrick.SelectClassTraits initialised.");
        }



	}
}
