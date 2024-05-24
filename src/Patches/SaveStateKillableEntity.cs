using HarmonyLib;

namespace ACTBossRespawner.Patches
{
    [HarmonyPatch(typeof(SaveStateKillableEntity))]
    public class SaveStateKillableEntityPatch
    {
        /// <summary>
        /// Patch for SaveStateKillableEntity.LoadFromFile to re-enable a permanently killed entity
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPrefix]
        [HarmonyPatch("LoadFromFile")]
        private static void LoadFromFile(SaveStateKillableEntity __instance)
        {
            if (__instance.name == Plugin.RespawnContext.SaveStateToReEnable)
            {
                Plugin.CustomLogger.LogInfo($"Re enabling {__instance.name}");
                Traverse.Create(__instance).Field("killedPreviously").SetValue(false);
                Traverse.Create(__instance).Field("killPermanently").SetValue(false);
            }
        }
    }
}
