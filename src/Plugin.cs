using ACTBossRespawner.Extensions;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine;

namespace ACTBossRespawner
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("AnotherCrabsTreasure.exe")]
    public class Plugin : BaseUnityPlugin
    {
        private Harmony harmony = new("ACTBossesRespawner.Harmony");
        public static ManualLogSource CustomLogger;
        public static bool IsCustomWarp = false;
        public static bool ShouldEnableDebug = false;
        public static RespawnContext RespawnContext = new();

        private void Awake()
        {
            HarmonyPatch();

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            CustomLogger = Logger;
        }

        private void OnDestroy()
        {
            this.harmony.UnpatchSelf();

            CustomLogger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is unloaded!");
        }

        private void HarmonyPatch()
        {
            var patches = typeof(Plugin).Assembly.GetTypes()
                .Where(m => m.GetCustomAttributes(typeof(HarmonyPatch), false).Length > 0)
                .ToArray();

            foreach (var patch in patches)
            {
                this.harmony.PatchAll(patch);
            }
        }

        public static void RestoreBackup()
        {
            if (!File.Exists(BackupInfo.BackupPath))
            {
                Plugin.CustomLogger.LogError("Backup file not found,restore aborted");
                return;
            }
            var backup = SaveData.instance.LoadFromFile(BackupInfo.BackupPath);
            GameManager.instance.activeCrabfile = backup;
            GUIManager.instance.Load(GUIManager.instance.blackFadeLoaderIllustrated, LevelDirector.instance.LoadGameFromLocation(CrabFile.current.locationData, fadeLoad: false, startTimer: true));
        }

        public static IEnumerator WarpRoutine(RespawnInfo info)
        {
            if (!File.Exists(BackupInfo.BackupPath))
            {
                Plugin.CustomLogger.LogInfo("First time warp with Boss, creating backup save file just in case ¯\\_(ツ)_/¯");
                if (!Directory.Exists($"{GameManager.persistentDataPath}{BackupInfo.Folder}"))
                {
                    Directory.CreateDirectory($"{GameManager.persistentDataPath}{BackupInfo.Folder}");
                }

                SaveData.instance.SaveScrobToFile(BackupInfo.Folder, CrabFile.current, 42, BackupInfo.Filename);
            }

            GUIManager.instance.CloseAllWindows();
            GameManager.events.TriggerShelleport();


            info.UpdateProgressIfNeeded();


            MSSCollectable targetLocation = info.Level.ToMSSCollectable();
            PlayerLocationData instance = ScriptableObject.CreateInstance<PlayerLocationData>();
            instance.SetSpawnerMSS(targetLocation.dest, targetLocation.index);

            GUIManager.instance.Load(GUIManager.instance.blackFadeLoaderIllustrated, LoadWarpLocationRoutine(targetLocation));
            AreaMap.RefreshDataMap(instance);
            yield break;
        }

        private static IEnumerator LoadWarpLocationRoutine(MSSCollectable targetLocation)
        {
            yield return (object)LevelDirector.instance.RemoveLevelMain();
            CrabFile.current.locationData.SetSpawnerMSS(targetLocation.dest, targetLocation.index);
            Plugin.IsCustomWarp = true;
            yield return (object)LevelDirector.instance.LoadGameFromLocation(CrabFile.current.locationData);
        }
    }
}
