using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Channels;

namespace ScaredScene
{
    public class CharacterMovement : MonoBehaviour
    {
        protected Animator anim;
        protected bool isWalking = false;
        protected float multiplierSpeed = 1f;
        protected float multiplierDirection = 0f;

        protected virtual void Start()
        {
            anim = GetComponent<Animator>();
        }

        public virtual void StepForward()
        {
            multiplierDirection = 1f;
            multiplierSpeed = 0f;
            StartWalking();
        }

        public virtual void TurnRight()
        {
            anim.SetTrigger("TurnRight");
        }

        public virtual void JumpDown()
        {
            multiplierDirection = 0f;
            isWalking = false;

            anim.SetBool("Walking", false);
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            anim.SetTrigger("JumpDown");
        }

        public void FreezeMovement()
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            anim.SetTrigger("Idle");
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
                float moveSpeed = Time.deltaTime * multiplierSpeed;
                float moveDirection = Time.deltaTime * multiplierDirection;
                transform.position = new Vector3(transform.position.x + moveSpeed, 5.479576f, transform.position.z - moveDirection);
            }
        }

        public virtual void Run()
        {
            anim.SetBool("Walking", false);
            anim.SetTrigger("Run");
            multiplierSpeed = 3f;
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
            multiplierSpeed = 2.5f;
            anim.SetBool("Run", false);
            anim.SetBool("Walking", true);
        }

        public virtual void Walk()
        {
            multiplierSpeed = 1f;
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
            isWalking = false;
        }
    }
}

