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
        private float multiplier = 0.5f;

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
                CheckPosition();
            }
        }

        private void CheckPosition()
        {
            if (transform.position.x > 197f && transform.position.x < 198f)
            {
                anim.SetTrigger("Run");
                multiplier = 3f;
            }
            if (!anim.GetBool("RunJump") && transform.position.x > 198.5f && transform.position.x < 198.6f)
            {
                anim.SetBool("Run", false);
                anim.SetBool("RunJump", true);
            }
            if (!anim.GetBool("Run") && transform.position.x > 201f && transform.position.x < 201.1f)
            {
                anim.SetBool("RunJump", false);
                anim.SetBool("Run", true);
            }
            if (transform.position.x > 201.5f && transform.position.x < 202.5f)
            {
                multiplier = 2.5f;
                anim.SetBool("Run", false);
                anim.SetTrigger("Walking");
            }
            if (transform.position.x > 202.5f && transform.position.x < 202.8f)
            {
                multiplier = 1f;
            }
            if (transform.position.x > 204.5f)
            {
                multiplier = 0f;
                anim.SetTrigger("TurnAround");
            }
        }

        public void ShiftIdle()
        {
            anim.SetBool("IsIdle", true);
            anim.SetTrigger("Idle");
        }
    }
}

