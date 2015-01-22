using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class Share : ActionBase
    {
        public Animator otherAnim;
        Animator anim;
        float rotation;
        bool listening = false;
        float turningTimer = 0.0f;

        public void Awake() {
            anim = GetComponent<Animator>();
        }

        public void StartTalking() {
            anim.SetTrigger("IsExpressing");
        }

        public void TriggerListening() {
            otherAnim.SetTrigger("IsListening");
            listening = true;
        }

        public void StartSitting() {
            anim.SetTrigger("IsSharing");
            otherAnim.SetTrigger("IsSharing");
            isCorrect = true;
            startTimer = true;
            eventTrigger = true;
        }

        // Update is called once per frame
        void Update()
        {
            base.Update();
            if (listening) {
                timer += Time.deltaTime;
                if (timer >= 2.5f) {
                    StartSitting();
                    listening = false;
                }
            }
        }
    }
}