using System.Collections;
using UnityEngine;

namespace SadScene
{
    public class OutsideGroupSoccerAnimationActionsMenu : OutsideGroupSoccerAnimation
    {
        protected override void Start()
        {
            base.Start();
            GUIInitialization.Initialize();
            GetComponent<CharacterMovement>().EnableParent();
            GetComponent<CapsuleCollider>().enabled = false;
        }

        protected IEnumerator ShowActionsMenu(string canvasName)
        {
            yield return new WaitForSeconds(2f);
            var previousCanvas = GUIHelper.GetPreviousGUI(canvasName);
            previousCanvas.GetComponent<Canvas>().enabled = true;
            GUIHelper.NextGUI();
        }
    }
}