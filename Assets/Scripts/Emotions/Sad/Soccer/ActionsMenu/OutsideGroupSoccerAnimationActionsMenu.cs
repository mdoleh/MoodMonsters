using System.Collections;
using UnityEngine;

namespace SadScene
{
    public class OutsideGroupSoccerAnimationActionsMenu : OutsideGroupSoccerAnimation
    {
        protected override void Start()
        {
            base.Start();
            global::GUIInitialization.Initialize();
            GetComponent<CharacterMovement>().EnableParent();
            GetComponent<CapsuleCollider>().enabled = false;
        }

        protected IEnumerator ShowActionsMenu(string canvasName)
        {
            yield return new WaitForSeconds(2f);
            GUIHelper.NextGUI();
        }
    }
}