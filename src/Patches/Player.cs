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


    }

}