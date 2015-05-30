using UnityEngine;
using System.Collections;

namespace ScaredScene
{
    public class RunAway : ActionBase
    {
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public override void StartAction()
        {
            base.StartAction();
            SadTurn();
        }

        private void SadTurn()
        {
            transform.Find("CameraFollow").gameObject.SetActive(false);
            anim.SetTrigger("SadTurn");
        }

        public void SadRunAway()
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            anim.SetBool("RunAway", true);
            GetComponent<FearfulMovement>().RunReverse();
            StartCoroutine(ResetScene());
        }

        private IEnumerator ResetScene()
        {
            yield return new WaitForSeconds(1.5f);
            sceneReset.TriggerSceneReset(audioSource, true);
            gameObject.SetActive(false);
        }
    }
}