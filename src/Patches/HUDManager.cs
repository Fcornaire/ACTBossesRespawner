using ACTBossRespawner.Extensions;
using HarmonyLib;

namespace ACTBossRespawner.Patches
{
    [HarmonyPatch(typeof(HUDManager))]
    public class HUDManagerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("SpawnBossHealthBar")]
        private static void SpawnBossHealthBar(Entity entity)
        {
            if (entity.name == Plugin.RespawnContext.SaveStateToReEnable || !string.IsNullOrEmpty(Plugin.RespawnContext.ActiveBossName))
            {
                Plugin.UpdateStatsIfNeeded();
                Player.singlePlayer.ResetStats();
            }
        }
    }
}
