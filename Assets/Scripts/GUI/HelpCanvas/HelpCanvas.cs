using UnityEngine;

namespace HelpGUI
{
    public class HelpCanvas : MonoBehaviour
    {
        private static HelpCanvas Instance;
        private GameObject disablePanel;
        private GameObject hintButton;

        private void Start()
        {
            Instance = this;
            disablePanel = transform.Find("DisablePanel").gameObject;
            hintButton = transform.Find("Help").gameObject;
        }

        public static void EnableHelpCanvas(bool enable)
        {
            Instance.GetComponent<Canvas>().enabled = enable;
        }

        public static void Interactive(bool interactive)
        {
            if (Instance != null && Instance.disablePanel != null)
                Instance.disablePanel.gameObject.SetActive(!interactive);
        }

        public static void EnableHintButton(bool enable)
        {
            Instance.hintButton.SetActive(enable);
        }
    }
}