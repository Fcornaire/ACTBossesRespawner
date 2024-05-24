using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace ACTBossRespawner.Extensions
{
    public static class MonoBehaviourExtensions
    {
        public static void CopyComponentFrom(this MonoBehaviour to, MonoBehaviour from)
        {
            var originalComponentFields = from.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var field in originalComponentFields)
            {
                var value = Traverse.Create(from).Field(field.Name).GetValue();
                Traverse.Create(to).Field(field.Name).SetValue(value);
            }
        }
    }
}
