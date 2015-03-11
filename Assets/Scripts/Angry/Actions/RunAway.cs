using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class RunAway : ActionBase
    {

        Animator anim;
        bool run = false;
        float rotation;

        public void Awake()
        {
            anim = GetComponent<Animator>();
        }

        protected override void Update() {
            base.Update();
            if (run)
            {
                float move = Time.deltaTime * 1.5f;
                transform.position = new Vector3(transform.position.x - move, transform.position.y, transform.position.z);
            }
        }

        public void StartRunningAway()
        {
            startTimer = true;
            eventTrigger = true;
            anim.SetTrigger("IsHiding");
            StartCoroutine(TriggerRun());
        }

        private IEnumerator TriggerRun()
        {
            yield return new WaitForSeconds(1.5f);
            transform.Rotate(new Vector3(0, 8f, 0));
            run = true;
        }

        public override void StartAction()
        {
            base.StartAction();
            StartRunningAway();
        }
    }
}