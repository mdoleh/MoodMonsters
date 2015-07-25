using UnityEngine;
using System.Collections;
using Globals;

namespace ScaredScene
{
    public class ExplainFear : ActionBase
    {
        public Animator otherAnim;
        public AudioSource scaredDialogue;
        public AudioSource afraidToFallDialogue;

        private void VoiceFear()
        {
            anim.SetTrigger("Talking");
            Utilities.PlayAudio(scaredDialogue);
        }

        public void GetEncouragement()
        {
            anim.SetTrigger("Idle");
            otherAnim.GetComponent<Conversation>().GiveEncouragement();
        }

        public void StartJumpSequence()
        {
            gameObject.GetComponent<FearfulMovement>().WalkBackwards();
        }

        public void AfraidToFall()
        {
            anim.SetTrigger("ScaredToFall");
            Utilities.PlayAudio(afraidToFallDialogue);
        }

        public void GetComfort()
        {
            anim.SetTrigger("Idle");
            otherAnim.GetComponent<Conversation>().GiveComfort();
        }

        public override void StartAction()
        {
            base.StartAction();
            ShowCorrect(true);
            StartCoroutine(Explain());
        }

        private IEnumerator Explain()
        {
            Utilities.PlayAudio(actionExplanation);
            yield return new WaitForSeconds(actionExplanation.clip.length);
            ShowCorrect(false);
            VoiceFear();
        }

        public void GoToMiniGame()
        {
            sceneReset.TriggerCorrect(null, Scenes.GetNextMiniGame(), false);
        }
    }
}