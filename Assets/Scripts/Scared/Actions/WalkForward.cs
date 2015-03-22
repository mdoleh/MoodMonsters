using UnityEngine;
using System.Collections;

namespace ScaredScene
{
    public class WalkForward : MonoBehaviour
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
            transform.Rotate(new Vector3(0f, 180f));
            anim.SetTrigger("Walking");
            other.SetTrigger("Walking");
        }
    }
}

