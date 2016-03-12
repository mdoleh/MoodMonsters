using System.Collections;
using UnityEngine;

namespace SadScene
{
    public class GroupSoccerAnimation : MonoBehaviour
    {
        public GroupSoccerBallMovement soccerBall;
        public Transform head;

        protected Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public virtual void KickForward()
        {
            stopBall("KickForward");
        }

        public void KickForwardEvent()
        {
            soccerBall.KickBallForward(transform.forward.normalized);
            StartCoroutine(RestoreCollider());
        }

        public void KickLeft()
        {
            stopBall("KickLeft");
        }

        public void KickLateralEvent()
        {
            soccerBall.KickBallLateral(head.forward);
            StartCoroutine(RestoreCollider());
        }

        public void KickRight()
        {
            stopBall("KickRight");
        }

        private void stopBall(string triggerName)
        {
            soccerBall.NeutralizeForce();
            if (GroupDialogue.shouldStopPlaying)
            {
                anim.SetTrigger("Idle");
                return;
            }
            anim.SetTrigger(triggerName);
        }

        private IEnumerator RestoreCollider()
        {
            yield return new WaitForSeconds(0.5f);
            GetComponent<CapsuleCollider>().enabled = true;
            anim.SetTrigger("Idle");
        }

        public void ResetCapsuleColliders()
        {
            GetComponent<CapsuleCollider>().enabled = true;
        }
    }
}

