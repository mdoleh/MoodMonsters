using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class WalkForward : MonoBehaviour
    {
        public Animator anim;
        public RunTutorial tutorial;
        private bool shouldStartWalking = false;

        public void StartWalking()
        {
            shouldStartWalking = true;
            Utilities.PlayAudio(audio);
        }

        private void Update()
        {
            if (shouldStartWalking)
            {
                float move = Time.deltaTime * 1.0f;
                transform.position = new Vector3(transform.position.x - move, transform.position.y, transform.position.z);
                if (transform.position.x <= 204.48f)
                {
                    StopWalking();
                    transform.position = new Vector3(204.48f, transform.position.y, transform.position.z);
                }
            }
        }

        private void StopWalking()
        {
            shouldStartWalking = false;
            anim.SetBool("IsWalking", false);
            anim.SetTrigger("IsIdle");
            tutorial.EnableHelpGUI();
        }
    }
}