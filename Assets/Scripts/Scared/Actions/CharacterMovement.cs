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
            if (transform.position.x > 197f)
            {
                anim.SetTrigger("Run");
                multiplier = 2.5f;
            }
            if (transform.position.x > 198f && transform.position.x < 198.5f)
            {
                anim.SetTrigger("RunJump");
            }
            if (transform.position.x > 201.5f)
            {
                multiplier = 0f;
                anim.SetTrigger("Run");
            }
        }

        public void StartRunning()
        {
            anim.SetTrigger("Run");
        }
    }
}

