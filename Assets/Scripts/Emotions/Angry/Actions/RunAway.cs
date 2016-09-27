using UnityEngine;
using System.Collections;

namespace AngryScene
{
    // Incorrect option choice for SituationActions
    public class RunAway : ActionBase
    {
        private bool run = false;
        private float rotation;
        private bool rotationHasCycledBack = false;

        protected void Update() {
            if (run)
            {
                float move = Time.deltaTime * 1.5f;
                anim.transform.position = new Vector3(anim.transform.position.x - move, anim.transform.position.y, anim.transform.position.z);
            }
            if (rotationHasCycledBack && anim.transform.rotation.eulerAngles.y <= 265f && !run)
            {
                anim.SetBool("IsTurning", false);
                anim.SetTrigger("IsHiding");
                run = true;
                StartCoroutine(triggerReset());
            }
            if (anim.transform.rotation.eulerAngles.y >= 350f)
            {
                rotationHasCycledBack = true;
            }
        }

        public void StartRunningAway()
        {
            anim.SetTrigger("IsHiding");
        }

        private IEnumerator triggerReset()
        {
            anim.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            yield return new WaitForSeconds(3f);
            sceneReset.TriggerSceneReset(actionExplanation, true);
        }

        public override void StartAction()
        {
            base.StartAction();
            StartRunningAway();
        }
    }
}