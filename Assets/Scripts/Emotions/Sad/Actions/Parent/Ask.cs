using UnityEngine;
using System.Collections;
using Globals;

namespace SadScene
{
    public class Ask : DefaultActionBase
    {
        public OutsideGroupDialogue child;
        public AudioSource theyWontLetMePlay;

        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
//            anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            base.AfterDialogue();
//            anim.SetTrigger("Idle");
            sceneReset.sceneToLoadIncorrect = "SadSceneSmallCitySituationActionsMenu";
            StartCoroutine(NextGUI());
        }

        private IEnumerator NextGUI()
        {
            yield return child.PlayDialogue(theyWontLetMePlay);
            child.TriggerIdleAnimation();
            var currentCanvas = GUIHelper.GetCurrentGUI();
            if (currentCanvas == null || !currentCanvas.name.ToLower().Contains("default"))
            {
                // something different
                yield return new WaitForSeconds(0f);
            }
            GUIHelper.GetPreviousGUI("ParentSupportCanvas" + GameFlags.ParentGender).enabled = true;
            GUIHelper.NextGUI();
        }
    }
}