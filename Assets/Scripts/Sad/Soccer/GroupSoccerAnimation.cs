using System;
using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class GroupSoccerAnimation : MonoBehaviour
    {
        public GroupSoccerBallMovement soccerBall;

        private Animator anim;
        private Action<Animator> animationTrigger;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void KickForward()
        {
            stopBallAnimation(animator => { anim.SetTrigger("KickForward"); });
        }

        public void KickForwardEvent()
        {
            soccerBall.KickBallForward(transform.forward.normalized);
            StartCoroutine(RestoreCollider());
        }

        public void KickLeft()
        {
            stopBallAnimation(animator => { anim.SetTrigger("KickLeft"); });
        }

        public void KickLeftEvent()
        {
            soccerBall.KickBallLeft();
            StartCoroutine(RestoreCollider());
        }

        public void KickRight()
        {
            stopBallAnimation(animator => { animator.SetTrigger("KickRight"); });
        }

        public void KickRightEvent()
        {
            soccerBall.KickBallRight();
            StartCoroutine(RestoreCollider());
        }

        public void StopBallEvent()
        {
            soccerBall.NeutralizeForce();
            animationTrigger(anim);
        }

        private void stopBallAnimation(Action<Animator> trigger)
        {
            animationTrigger = trigger;
            anim.SetTrigger("StopBall");
        }

        private IEnumerator RestoreCollider()
        {
            yield return new WaitForSeconds(1f);
            GetComponent<CapsuleCollider>().enabled = true;
            anim.SetTrigger("Idle");
        }
    }
}

