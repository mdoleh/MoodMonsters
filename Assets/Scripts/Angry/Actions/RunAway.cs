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

        protected void Update() {
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
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            yield return new WaitForSeconds(2.0f);
            anim.SetTrigger("IsHiding");
            run = true;
            yield return new WaitForSeconds(3.5f);
            sceneReset.TriggerSceneReset(actionExplanation, true);
        }

        public override void StartAction()
        {
            base.StartAction();
            StartRunningAway();
        }
    }
}