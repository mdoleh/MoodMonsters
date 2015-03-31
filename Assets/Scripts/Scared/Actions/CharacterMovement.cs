using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Channels;

namespace ScaredScene
{
    public class CharacterMovement : MonoBehaviour
    {
        private Animator anim;
        private Animator otherAnim;
        private GameObject otherCharacter;
        private bool isWalking = false;
        private float multiplier = 1f;

        private void Start()
        {
            anim = GetComponent<Animator>();
            otherCharacter = GameObject.Find("Aj");
            otherAnim = otherCharacter.GetComponent<Animator>();
        }

        public void StartTurning()
        {
            anim.SetTrigger("TurnAround");
            otherAnim.SetTrigger("Idle");
        }

        public void StartWalking()
        {
            anim.SetTrigger("Walking");
            otherAnim.SetTrigger("Walking");
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

