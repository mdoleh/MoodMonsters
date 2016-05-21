using Globals;
using UnityEngine;

namespace PreSceneMenus
{
    public class AdultPresent : DelayShowCanvas
    {
        public void Yes()
        {
            Timeout.StopTimers();
            GameFlags.AdultIsPresent = true;
            GUIHelper.NextGUI();
        }

        public void No()
        {
            GameFlags.AdultIsPresent = false;
            GameFlags.ParentGender = Random.Range(0, 2) == 0 ? "Mom" : "Dad";
            Timeout.StopTimers();
            Utilities.LoadEmotionScene(Scenes.GetNextEmotionSceneToLoad("SadSceneSmallCity"));
        }
    }
}