using UnityEngine;
using System.Collections;
using Globals;

namespace ScaredScene
{
    public class ExplainFear : ActionBase
    {
        public Animator otherAnim;
        public AudioSource scaredDialogue;
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void VoiceFear()
        {
            anim.SetTrigger("Talking");
            Utilities.PlayAudio(scaredDialogue);
        }

        public void GetComfort()
        {
            anim.SetTrigger("Idle");
            otherAnim.GetComponent<Conversation>().StartTalking();
        }

        public void StartJumpSequence()
        {
            gameObject.GetComponent<FearfulMovement>().WalkBackwards();
        }

        public override void StartAction()
        {
            base.StartAction();
            ShowCorrect(true);
            StartCoroutine(Explain());
        }

        private IEnumerator Explain()
        {
            Utilities.PlayAudio(audioSource);
            yield return new WaitForSeconds(audioSource.clip.length);
            ShowCorrect(false);
            VoiceFear();
        }

        public void GoToMiniGame()
        {
            sceneReset.TriggerCorrect(null, Scenes.GetNextMiniGame(), false);
        }
    }
}