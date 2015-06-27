using UnityEngine;
using System.Collections;
using Globals;

namespace AngryScene
{
    public class Share : ActionBase
    {
        public Animator otherAnim;
        Animator anim;
        float rotation;
        bool listening = false;
        private bool sharingTriggered = false;

        public void Awake()
        {
            anim = GetComponent<Animator>();
        }

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
            StartCoroutine(DelayMoveIpad());
            StartCoroutine(TriggerSitting());
        }

        private IEnumerator TriggerSitting()
        {
            yield return new WaitForSeconds(2.5f);
            Timeout.StopTimers();
            StartWalking();
        }

        private IEnumerator DelayMoveIpad()
        {
            yield return new WaitForSeconds(0.5f);
            MoveIpadToUnderArm();
            yield return new WaitForSeconds(3.5f);
            MoveIpadToLap();
        }

        private void MoveIpadToLap()
        {
            var ipad = GameObject.Find("iPad");
            ipad.transform.localPosition = new Vector3(0.224f, 0.145f, 0.043f);
//            ipad.transform.localPosition = new Vector3(0.02198f, -0.199f, 0.08892f);
//            ipad.transform.localRotation = Quaternion.Euler(292.6998f, 36.10002f, 33.00001f);
            ipad.transform.localRotation = Quaternion.Euler(15.41914f, 158.8406f, 1.443392f);
        }

        private void MoveIpadToUnderArm()
        {
            var ipad = GameObject.Find("iPad");
            ipad.transform.localPosition = new Vector3(0.04f, -0.073f, 0.049f);
//            ipad.transform.localPosition = new Vector3(0.035966f, -0.059901f, 0.10305f);
            ipad.transform.localRotation = Quaternion.Euler(352.4399f, 357.2535f, 10.56083f);
//            ipad.transform.localRotation = Quaternion.Euler(76.59476f, 69.17188f, 104.7559f);
        }

        public void StartWalking()
        {
            anim.SetBool("IsWalking", true);
            otherAnim.SetTrigger("IsSharing");
            StartCoroutine(LoadMiniGame());
        }

        public void StartSitting()
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            anim.SetTrigger("IsSharing");
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
                    anim.SetTrigger("IsSharing");
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