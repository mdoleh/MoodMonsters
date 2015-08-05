using UnityEngine;
using System.Collections;
using ScaredScene;

namespace ScaredScene
{
    public class Comfort : CorrectActionBase
    {
        public ExplainFear fearfulCharacter;
        public Conversation fearlessCharacter;
        public AudioSource comfortDialogue;
        public AudioSource successDialogue;
        public AudioSource explanationAudio;

        protected override void DialogueAnimation()
        {
            //        anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            //            anim.SetTrigger("Idle");
            fearfulCharacter.AfraidToFall();
        }

        public void GiveComfort()
        {
            //            anim.SetTrigger("Comfort");
            StartCoroutine(PlayComfortDialogue());
        }

        private IEnumerator PlayComfortDialogue()
        {
            Utilities.PlayAudio(comfortDialogue);
            yield return new WaitForSeconds(comfortDialogue.clip.length);
            //            anim.SetTrigger("Idle");
            fearfulCharacter.StartJumpSequence();
        }

        public void StartClapping()
        {
            //            anim.SetTrigger("Clap");
            fearlessCharacter.ClappingAnimation();
            StartCoroutine(PlayClappingDialogue());
        }

        private IEnumerator PlayClappingDialogue()
        {
            Utilities.PlayAudio(successDialogue);
            yield return new WaitForSeconds(successDialogue.clip.length);
            Utilities.PlayAudio(explanationAudio);
            yield return new WaitForSeconds(explanationAudio.clip.length);
            fearfulCharacter.gameObject.GetComponent<ExplainFear>().GoToMiniGame();
        }
    }
}