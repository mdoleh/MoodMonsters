using UnityEngine;
using System.Collections;
using Globals;

namespace SadScene
{
    public class ConveySadness : CorrectActionBase
    {
        public AudioSource switchToParentAudio;

        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            base.AfterDialogue();
            anim.SetTrigger("Idle");
            sceneReset.sceneToLoadIncorrect = "SadSceneSmallCityParentActionsMenu";
            StartCoroutine(SwitchToParent());
        }

        private IEnumerator SwitchToParent()
        {
            if (GameFlags.AdultIsPresent)
            {
                Utilities.PlayAudio(switchToParentAudio);
                yield return new WaitForSeconds(switchToParentAudio.clip.length);
                GUIHelper.GetPreviousGUI("ParentPayAttentionAskCanvas" + GameFlags.ParentGender).enabled = true;
            }
            else
            {
                GUIHelper.GetPreviousGUI("ParentDefaultCanvas").enabled = true;
            }
            GUIHelper.NextGUI();
        }
    }
}