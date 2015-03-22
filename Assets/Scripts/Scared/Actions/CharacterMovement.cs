using UnityEngine;
using System.Collections;

namespace ScaredScene
{
    public class CharacterMovement : MonoBehaviour
    {
        private Animator anim;
        private Animator other;

        private void Start()
        {
            anim = GetComponent<Animator>();
            other = GameObject.Find("Aj").GetComponent<Animator>();
        }

        public void StartTurning()
        {
            anim.SetTrigger("TurnAround");
            other.SetTrigger("Idle");
        }

        public void StartWalking()
        {
            anim.SetTrigger("Walking");
            other.SetTrigger("Walking");
        }
    }
}

