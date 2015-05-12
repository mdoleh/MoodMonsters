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
            anim.SetBool("IsIdle", false);
            anim.SetTrigger("TurnAround");
        }

        public virtual void StartWalking()
        {
            anim.SetBool("Walking", true);
            isWalking = true;
        }

        protected virtual void Update()
        {
            if (isWalking)
            {
                float move = Time.deltaTime * multiplier;
                transform.position = new Vector3(transform.position.x + move, transform.position.y, transform.position.z);
            }
        }

        public virtual void Run()
        {
            anim.SetBool("Walking", false);
            anim.SetTrigger("Run");
            multiplier = 3f;
        }

        public virtual void RunJump()
        {
            if (!anim.GetBool("RunJump"))
            {
                transform.position = new Vector3(transform.position.x, 5.427f, transform.position.z);
                anim.SetBool("Run", false);
                anim.SetBool("RunJump", true);
            }
        }

        public virtual void JumpToRun()
        {
            if (!anim.GetBool("Run"))
            {
                transform.position = new Vector3(transform.position.x, 5.445f, transform.position.z);
                anim.SetBool("RunJump", false);
                anim.SetBool("Run", true);
            }
        }

        public virtual void RunToWalk()
        {
            multiplier = 2.5f;
            anim.SetBool("Run", false);
            anim.SetBool("Walking", true);
        }

        public virtual void Walk()
        {
            multiplier = 1f;
        }

        public virtual void TurnAround()
        {
            isWalking = false;
            anim.SetBool("Walking", false);
            anim.SetTrigger("TurnAround");
        }

        public virtual void ShiftIdle()
        {
            anim.SetTrigger("Idle");
        }

        public virtual void EdgeSlip()
        {
            anim.SetBool("Run", false);
            anim.SetTrigger("Stumble");
            //AdjustPositionForEdgeSlip();
            isWalking = false;
        }

        private void AdjustPositionForEdgeSlip()
        {
            var center = GetComponent<BoxCollider>().center;
            GetComponent<BoxCollider>().center = new Vector3(center.x, 1.5f, center.z);
            transform.position = new Vector3(transform.position.x, 4.87f, transform.position.z);
        }
    }
}

