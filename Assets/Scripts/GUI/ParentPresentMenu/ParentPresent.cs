using UnityEngine;
using System.Collections;
using Globals;

namespace ParentPresentMenu
{
    public class ParentPresent : MonoBehaviour
    {
        private void Start()
        {
            GUIInitialization.Initialize();
            StartCoroutine(DelayShowCanvas());
        }

        private IEnumerator DelayShowCanvas()
        {
            yield return new WaitForSeconds(2f);
            GUIHelper.NextGUI(string.Empty, "ParentPresentCanvas");
        }

        public void Yes()
        {
            GameFlags.AdultIsPresent = true;
            GUIHelper.NextGUI();
        }

        public void No()
        {
            GameFlags.AdultIsPresent = false;
            Timeout.StopTimers();
            Utilities.LoadEmotionScene(Scenes.GetNextSceneToLoadForParentPresent());
        }
    }
}