using ACTBossRespawner.Extensions;
using HarmonyLib;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ACTBossRespawner.Patches
{
    [HarmonyPatch(typeof(PauseMenuManager))]
    public class PauseMenuManagerPatch
    {

        /// <summary>
        /// Patch for PauseMenuManager.OpenWindow to add a new tab for the BossesRespawner
        /// </summary>
        [HarmonyPostfix]
        [HarmonyPatch("OpenWindow")]
        private static void OpenWindow()
        {
            if (GUIManager.instance.pauseMenu.tabs.Any(tab => tab.name == "BossesRespawner"))
            {
                GUIManager.instance.pauseMenu.tabs.RemoveAll(tab => tab.name == "BossesRespawner");
                //return;
            }

            var window = UnityEngine.Object.Instantiate<MenuWindow>(GUIManager.instance.pauseMenu.debugPanel);
            window.transform.SetParent(GUIManager.instance.pauseMenu.debugPanel.transform.GetParent());
            window.transform.localScale = new Vector3(1.01f, 1.01f, 1.01f);
            window.displayName = "BossesRespawner";
            window.name = "BossesRespawner";

            var rectTransform = window.GetComponent<RectTransform>();
            var debugPanelRectTransform = GUIManager.instance.pauseMenu.debugPanel.GetComponent<RectTransform>();
            rectTransform.anchorMin = debugPanelRectTransform.anchorMin;
            rectTransform.anchorMax = debugPanelRectTransform.anchorMax;
            rectTransform.offsetMin = debugPanelRectTransform.offsetMin;
            rectTransform.offsetMax = debugPanelRectTransform.offsetMax;
            rectTransform.sizeDelta = debugPanelRectTransform.sizeDelta;

            var display = window.transform.Find("Display");
            display.name = "Display Bosses Respawner";

            for (int i = display.childCount - 1; i >= 0; i--)
            {
                UnityEngine.Object.Destroy(display.GetChild(i).gameObject);
            }

            var grid = display.gameObject.GetComponent<GridLayoutGroup>();
            grid.cellSize = new Vector2(350, 75.5f);
            grid.spacing = new Vector2(15, 15);

            var warpToShell = GUIManager.instance.pauseMenu.debugPanel.GetComponentsInChildren<Button>().First(Button => Button.name == "Warp To Shell");

            foreach (var respawnInfo in Plugin.RespawnContext.RespawnInfos.Where(info => info.IsEnabled))
            {
                GameObject buttonParent = UnityEngine.Object.Instantiate(new GameObject(respawnInfo.BossName));
                buttonParent.transform.SetParent(display.transform);
                var buttonParentRectTransform = buttonParent.AddComponent<RectTransform>();
                buttonParentRectTransform.localScale = new Vector3(1, 1, 1);

                var buttonFlag = buttonParent.AddComponent<ButtonFlag>();
                buttonFlag.playSelectSound = true;
                buttonFlag.selectSound = "UI/UI_Scroll_List";
                buttonFlag.playPushSound = true;
                buttonFlag.pushSound = "UI/UI_Confirm_Soft";
                buttonFlag.enabled = true;
                buttonFlag.onClick = new UnityEvent();
                buttonFlag.onSelect = new UnityEvent();
                buttonFlag.onEnter = new UnityEvent();
                buttonFlag.onClick.AddListener(() =>
                {
                    Plugin.RespawnContext.SaveStateToReEnable = respawnInfo.SaveState;
                    Plugin.RespawnContext.ActiveBossName = respawnInfo.BossName;
                    GameManager.instance.StartCoroutine(Plugin.WarpRoutine(respawnInfo));
                });

                var image = buttonParent.AddComponent<Image>();
                var originalImage = warpToShell.GetComponent<Image>();
                image.CopyComponentFrom(originalImage);

                var button = buttonParent.AddComponent<Button>();
                var originalButton = warpToShell.GetComponent<Button>();
                button.colors = originalButton.colors;
                button.name = respawnInfo.SaveState;
                button.transition = Selectable.Transition.ColorTint;
                button.transform.SetParent(buttonParent.transform);

                var TextMeshPRoObj = new GameObject($"TMP_{respawnInfo.BossName}");
                var textMeshPro = TextMeshPRoObj.AddComponent<TextMeshProUGUI>();
                var originalTextMeshPro = warpToShell.GetComponentInChildren<TextMeshProUGUI>();
                textMeshPro.text = respawnInfo.BossName;
                textMeshPro.font = originalTextMeshPro.font;
                textMeshPro.fontSize = originalTextMeshPro.fontSize;
                textMeshPro.fontSharedMaterial = originalTextMeshPro.fontSharedMaterial;
                textMeshPro.alignment = originalTextMeshPro.alignment;
                textMeshPro.enableWordWrapping = originalTextMeshPro.enableWordWrapping;
                textMeshPro.transform.SetParent(button.transform);
            }
            GUIManager.instance.pauseMenu.tabs.Add(window);
        }

        [HarmonyPrefix]
        [HarmonyPatch("SetDebug")]
        private static void SetDebug(ref bool active)
        {
            active = Plugin.ShouldEnableDebug;
        }
    }
}
