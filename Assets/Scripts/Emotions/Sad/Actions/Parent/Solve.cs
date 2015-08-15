using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using Globals;

namespace SadScene
{
    public class Solve : DefaultActionBase
    {
        public AudioSource switchToChildAudio;
        public GameObject PASSLetter;
        public GameObject[] PASSLetters;

        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            GameFlags.HasSeenPASS = true;
            PASSLetters.ToList().ForEach(x => x.SetActive(false));
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

        protected override void BeforeExplanation()
        {
            base.BeforeExplanation();
            PASSLetter.SetActive(true);
            PASSLetter.GetComponent<Animator>().SetTrigger("BlowUp");
        }

        protected override void BeforeAdditionalExplanation()
        {
            base.BeforeAdditionalExplanation();
            PASSLetters.ToList().ForEach(x => x.GetComponent<Animator>().SetTrigger("BlowUp"));
        }
    }
}