using UnityEngine;
using System.Collections;
using Globals;

namespace ParentPresentMenu
{
    public class ManOrWoman : MonoBehaviour
    {
        public void Man()
        {
            GameFlags.ParentGender = "Dad";
            handleClick();
        }

        public void Woman()
        {
            GameFlags.ParentGender = "Mom";
            handleClick();
        }

        private void handleClick()
        {
            Timeout.StopTimers();
            Utilities.LoadEmotionScene(Scenes.GetNextSceneToLoadForParentPresent());
        }
    }
}