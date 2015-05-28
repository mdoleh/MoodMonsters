using UnityEngine;
using System.Collections;

namespace ScaredScene
{
    public class ExplainFear : ExpressAction
    {
        public Animator otherAnim;
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void StartTalking()
        {
            anim.SetTrigger("Talking");
            Utilities.PlayAudio(GetComponent<AudioSource>());
        }

        public void StartListening()
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
            StartTalking();
        }
    }
}