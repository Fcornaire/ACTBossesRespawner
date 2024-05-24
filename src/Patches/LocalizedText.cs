using HarmonyLib;
using System;

namespace ACTBossRespawner.Patches
{
    [HarmonyPatch(typeof(LocalizedText))]
    public class LocalizedTextPatch
    {
        /// <summary>
        /// Patch for LocalizedText.GetText to prevent the game trying to get a text for "BossesRespawner"
        /// </summary>
        [HarmonyPrefix]
        [HarmonyPatch("GetText", new Type[] { typeof(string), typeof(bool) })]
        private static bool GetText(ref string __result, string id)
        {
            if (id == "BossesRespawner")
            {
                __result = "Bosses Respawner";
                return false;
            }
            return true;
        }
    }
}
