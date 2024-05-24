using HarmonyLib;

namespace ACTBossRespawner.Patches
{
    [HarmonyPatch(typeof(GameManager))]
    public class GameManagerPatch
    {
        /// <summary>
        /// Patch for GameManager.PlacePlayerInWorld to warp the player to the boss location instead of the shell location in the save file
        /// </summary>
        [HarmonyPrefix]
        [HarmonyPatch("PlacePlayerInWorld")]
        private static void PlacePlayerInWorld()
        {
            if (Plugin.IsCustomWarp)
            {
                CrabFile.current.locationData.spawnIn = PlayerLocationData.SpawnIn.AnyPos;
                CrabFile.current.locationData.spawnPos = Plugin.RespawnContext.RespawnInfos.Find(info => info.BossName == Plugin.RespawnContext.ActiveBossName).RespawnPlayerAt;
                Plugin.CustomLogger.LogInfo($"Warping player to {CrabFile.current.locationData.spawnPos}");
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("PlacePlayerInWorld")]
        private static void PlacePlayerInWorldPost()
        {
            if (Plugin.IsCustomWarp)
            {
                Plugin.IsCustomWarp = false;
            }
        }

    }

    /// <summary>
    /// Patch for PlayerLocationData.RevertSpawnIn to prevent reverting the spawn in location to the shell location
    /// (i swear this came from the game latest update and was not there before)
    /// </summary>
    [HarmonyPatch(typeof(PlayerLocationData))]
    public class PlayerLocationDataPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("RevertSpawnIn")]
        private static bool RevertSpawnIn(PlayerLocationData __instance)
        {
            if (Plugin.IsCustomWarp)
            {
                Plugin.IsCustomWarp = false;
                Plugin.CustomLogger.LogInfo($"Prevent Reverting spawn in {__instance.lastSpawnIn}");
                return false;
            }

            return true;
        }

    }
}
