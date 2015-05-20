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
        }

        public void StartListening()
        {
            anim.SetTrigger("Idle");
            otherAnim.SetTrigger("Listening");
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