using UnityEngine;
using System.Collections;

namespace GameIntro
{
    // Makes the adult models walk into frame
    public class ParentMovement : MonoBehaviour
    {
        public float WALKING_SPEED = 0.01f;
        private Animator anim;
        private bool stopWalking = false;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void Turn()
        {
            anim.SetTrigger("Turn");
            stopWalking = true;
        }

        public void ShiftIdle()
        {
            anim.SetTrigger("Idle");
        }

        private void Update()
        {
            if (stopWalking) return;
            transform.position += transform.forward * WALKING_SPEED;
        }
    }
}