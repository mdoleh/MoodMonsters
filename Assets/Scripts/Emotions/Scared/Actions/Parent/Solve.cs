using System.Collections;
using System.Linq;
using Globals;
using UnityEngine;

namespace ScaredScene
{
    public class Solve : DefaultActionBase
    {
        public ExplainFear fearfulCharacter;
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
            sceneReset.sceneToLoadIncorrect = "ScaredSceneSmallCityActionsMenu";
            StartCoroutine(SwitchBackToChild());
        }

        private IEnumerator SwitchBackToChild()
        {
            Utilities.PlayAudio(switchToChildAudio);
            yield return new WaitForSeconds(switchToChildAudio.clip.length);
            fearfulCharacter.StartJumpSequence();
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