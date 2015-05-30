using UnityEngine;
using System.Collections;
using Globals;

namespace ScaredScene
{
    public class ExplainFear : ExpressAction
    {
        public Animator otherAnim;
        private Animator anim;
        private AudioSource correctAudio;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            correctAudio =
                GameObject.Find("ActionsCanvas")
                    .transform.FindChild("Express")
                    .FindChild("Text")
                    .GetComponent<AudioSource>();
        }

        private void VoiceFear()
        {
            anim.SetTrigger("Talking");
            Utilities.PlayAudio(GetComponent<AudioSource>());
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
            Utilities.PlayAudio(correctAudio);
            yield return new WaitForSeconds(correctAudio.clip.length);
            ShowCorrect(false);
            VoiceFear();
        }

        public void GoToMiniGame()
        {
            sceneReset.TriggerCorrect(null, Scenes.GetNextMiniGame(), false);
        }
    }
}