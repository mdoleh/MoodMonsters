using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class Share : ActionBase
    {
        public Animator otherAnim;
        Animator anim;
        Transform other;
        float rotation;
        bool listening = false;
        float turningTimer = 0.0f;

        public void Awake() {
            anim = GetComponent<Animator>();
            other = otherAnim.GetComponent<Transform>();
        }

        public void StartTalking() {
            anim.SetTrigger("IsExpressing");
        }

        public void TriggerListening() {
            otherAnim.SetTrigger("IsListening");
            listening = true;
        }

        public void StartTurning() {
            rotation = transform.rotation.eulerAngles.y;
            anim.SetBool("IsTurning", true);
            otherAnim.SetTrigger("IsTurning");
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
            if (anim.GetBool("IsTurning") && Mathf.Abs(transform.rotation.eulerAngles.y - rotation) >= 80)
            {
                anim.SetBool("IsTurning", false);
                StartSitting();
            }
            if (listening) {
                timer += Time.deltaTime;
                if (timer >= 2.5f) {
                    StartTurning();
                    listening = false;
                }
            }
        }

        public void UpdateRotation()
        {
//            transform.rotation = Quaternion.Euler(new Vector3(0, -90.0f, 0));
//            other.rotation = Quaternion.Euler(new Vector3(0, -90.0f, 0));
//            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y - 85.0f, 0));
            transform.Rotate(new Vector3(0, 90.0f, 0));
            other.Rotate(new Vector3(0, 90.0f, 0));
        }
    }
}