using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Channels;

namespace ScaredScene
{
    public class CharacterMovement : MonoBehaviour
    {
        protected Animator anim;
        protected bool isWalking = false;
        protected float multiplier = 1f;

        protected virtual void Start()
        {
            anim = GetComponent<Animator>();
        }

        public virtual void StartSequence()
        {
            anim.SetTrigger("TurnAround");
        }

        public virtual void StartWalking()
        {
            anim.SetTrigger("Walking");
            isWalking = true;
        }

        private void Update()
        {
            if (isWalking)
            {
                float move = Time.deltaTime * multiplier;
                transform.position = new Vector3(transform.position.x + move, transform.position.y, transform.position.z);
            }
        }

        public void Run()
        {
            anim.SetTrigger("Run");
            multiplier = 3f;
        }

        public void RunJump()
        {
            if (!anim.GetBool("RunJump"))
            {
                anim.SetBool("Run", false);
                anim.SetBool("RunJump", true);
            }
        }

        public void JumpToRun()
        {
            if (!anim.GetBool("Run"))
            {
                anim.SetBool("RunJump", false);
                anim.SetBool("Run", true);
            }
        }

        public void RunToWalk()
        {
            multiplier = 2.5f;
            anim.SetBool("Run", false);
            anim.SetTrigger("Walking");
        }

        public void Walk()
        {
            multiplier = 1f;
        }

        public void TurnAround()
        {
            multiplier = 0f;
            anim.SetTrigger("TurnAround");
        }

        public void ShiftIdle()
        {
            anim.SetBool("IsIdle", true);
            anim.SetTrigger("Idle");
        }
    }
}

