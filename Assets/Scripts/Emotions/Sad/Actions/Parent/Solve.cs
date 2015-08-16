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
            if (GameFlags.AdultIsPresent)
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
            if (!GameFlags.AdultIsPresent) return;
            PASSLetter.SetActive(true);
            PASSLetter.GetComponent<Animator>().SetTrigger("BlowUp");
        }

        protected override void BeforeAdditionalExplanation()
        {
            base.BeforeAdditionalExplanation();
            if (!GameFlags.AdultIsPresent) return;
            PASSLetters.ToList().ForEach(x => x.GetComponent<Animator>().SetTrigger("BlowUp"));
        }
    }
}