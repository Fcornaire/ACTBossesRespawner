using ACTBossRespawner.Extensions;
using HarmonyLib;
using UnityEngine;

namespace ACTBossRespawner.Patches
{

    [HarmonyPatch(typeof(Player))]
    public class PlayerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        private static void Update()
        {
            if (BepInEx.UnityInput.Current.GetKeyDown(KeyCode.F5))
            {
                Plugin.CustomLogger.LogInfo("Restoring backup...");
                Plugin.RestoreBackup();
            }

            if (BepInEx.UnityInput.Current.GetKeyDown(KeyCode.F6))
            {
                Plugin.ShouldEnableDebug = !Plugin.ShouldEnableDebug;

                if (Plugin.ShouldEnableDebug)
                {
                    Plugin.CustomLogger.LogInfo("Debug mode enabled!");
                }
                else
                {
                    Plugin.CustomLogger.LogInfo("Debug mode disabled!");
                }
            }

            if (BepInEx.UnityInput.Current.GetKeyDown(KeyCode.F7))
            {
                Plugin.CustomLogger.LogInfo($"Player pos : {Player.singlePlayer.transform.position}");
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("OnBossKilled")]
        private static void OnBossKilled(Player __instance)
        {
            if (Plugin.HasModifedStats)
            {
                Plugin.CustomLogger.LogInfo("Boss killed, restoring stats...");
                var backup = SaveData.instance.LoadFromFile(BackupInfo.BackupPath);

                CrabFile.current.inventoryData["Level_VIT"].amount = backup.inventoryData["Level_VIT"].amount;
                CrabFile.current.inventoryData["Level_ATK"].amount = backup.inventoryData["Level_ATK"].amount;
                CrabFile.current.inventoryData["Level_RES"].amount = backup.inventoryData["Level_RES"].amount;
                CrabFile.current.inventoryData["Level_MSG"].amount = backup.inventoryData["Level_MSG"].amount;

                Plugin.HasModifedStats = false;

                __instance.ResetStats();
            }

            Plugin.RespawnContext.ActiveBossName = string.Empty;
        }


    }

}