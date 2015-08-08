using UnityEngine;
using System.Collections;
using Globals;

namespace SadScene
{
    public class Comfort : DefaultActionBase
    {
        public AudioSource switchToChildAudio;

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
            StartCoroutine(SwitchBackToChild());
        }

        private IEnumerator SwitchBackToChild()
        {
            var currentCanvas = GUIHelper.GetCurrentGUI();
            if (currentCanvas == null || !currentCanvas.name.ToLower().Contains("default"))
            {
                Utilities.PlayAudio(switchToChildAudio);
                yield return new WaitForSeconds(switchToChildAudio.clip.length);
            }
            GUIHelper.GetPreviousGUI("SituationActionsCanvas").enabled = true;
            GUIHelper.NextGUI();
        }
    }
}