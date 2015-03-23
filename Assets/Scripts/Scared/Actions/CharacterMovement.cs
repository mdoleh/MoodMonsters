using UnityEngine;
using System.Collections;

namespace ScaredScene
{
    public class CharacterMovement : MonoBehaviour
    {
        private Animator anim;
        private Animator otherAnim;
        private GameObject otherCharacter;
        private bool isWalking = false;

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
                float move = Time.deltaTime * 0.5f;
                transform.position = new Vector3(transform.position.x + move, transform.position.y, transform.position.z);
            }
        }
    }
}

