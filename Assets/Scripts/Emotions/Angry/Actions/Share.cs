using UnityEngine;
using System.Collections;
using Globals;

namespace AngryScene
{
    // Correct option choice for SituationActions
    public class Share : ActionBase
    {
        public Animator otherAnim;
        private float rotation;
        private bool listening = false;
        private bool sharingTriggered = false;

        public void StartTalking()
        {
            anim.SetTrigger("IsExpressing");
            var maybeShare = transform.FindChild("Dialogue").FindChild("Share").GetComponent<AudioSource>();
            Utilities.PlayAudio(maybeShare);
            sharingTriggered = true;
        }

        public void TriggerListening()
        {
            if (!sharingTriggered) return;
            otherAnim.SetTrigger("IsListening");
            var okay = otherAnim.transform.FindChild("Dialogue").FindChild("Okay").GetComponent<AudioSource>();
            Utilities.PlayAudio(okay);
            StartCoroutine(TriggerSharing());
        }

        private IEnumerator TriggerSharing()
        {
            yield return new WaitForSeconds(2.5f);
            Timeout.StopTimers();
            StartWalking();
        }

        public void StartWalking()
        {
            anim.SetBool("IsWalking", true);
            otherAnim.SetTrigger("IsSharing");
            StartCoroutine(LoadMiniGame());
        }

        public void FreezeAllMovement()
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        private IEnumerator LoadMiniGame()
        {
            yield return new WaitForSeconds(4f);
            sceneReset.TriggerCorrect(actionExplanation, Scenes.GetNextMiniGame(), true);
        }

        protected void Update()
        {
            if (anim.GetBool("IsWalking"))
            {
                float move = Time.deltaTime * 0.5f;
                transform.position = new Vector3(transform.position.x + move, transform.position.y, transform.position.z);
                if (transform.position.x >= 204.037f)
                {
                    anim.SetBool("IsWalking", false);
                    anim.SetBool("IsSharing", true);
                }
            }
        }

        public override void StartAction()
        {
            base.StartAction();
            StartTalking();
        }
    }
}