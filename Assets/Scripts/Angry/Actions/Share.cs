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
        private bool sharingTriggered = false;

        public void Awake() {
            anim = GetComponent<Animator>();
        }

        public void StartTalking() {
            anim.SetTrigger("IsExpressing");
            sharingTriggered = true;
        }

        public void TriggerListening() {
            otherAnim.SetTrigger("IsListening");
            StartCoroutine(DelayMoveIpad());
            listening = true;
        }

        private IEnumerator DelayMoveIpad()
        {
            yield return new WaitForSeconds(0.5f);
            MoveIpad();
        }

        private void MoveIpad()
        {
            if (!sharingTriggered) return;
            var ipad = GameObject.Find("iPad");
            var bench = GameObject.Find("Bench");
            ipad.transform.parent = bench.transform;
            ipad.transform.localPosition = new Vector3(-0.48035f, 2.7818f, 2.3755f);
            ipad.transform.localRotation = Quaternion.Euler(270f, 0f, 0f);
            ipad.transform.localScale = new Vector3(1f, 1f, 1f);
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