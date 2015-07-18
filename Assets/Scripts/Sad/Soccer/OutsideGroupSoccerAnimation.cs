using System;
using UnityEngine;
using System.Collections;
using Globals;

namespace SadScene
{
    public class OutsideGroupSoccerAnimation : ControllerMovement
    {
        public OutsideGroupSoccerBallMovement soccerBall;
        
        private Animator anim;

        protected void Start()
        {
            base.Start();
            anim = GetComponent<Animator>();
        }

        public void SetWalkAwaySpeed()
        {
            isWalking = true;
            multiplierSpeed = -0.5f;
            multiplierDirection = 0f;
        }

        public void ShiftIdle()
        {
            anim.SetTrigger("Idle");
            AdjustCamera();
            StartJoystickTutorial();
        }

        public void KickBallUp()
        {
            soccerBall.KickBallUp();
        }

        public void KickForward()
        {
            stopMoving();
            resetCamera(true);
            StartCoroutine(KickBallForward());
        }

        public void StartDialogue()
        {
            stopMoving();
            resetCamera(false);
            Timeout.StopTimers();
            GetComponent<OutsideGroupDialogue>().StartDialogue();
        }

        public void KickForwardEvent()
        {
            soccerBall.KickBallForward();
        }

        private IEnumerator KickBallForward()
        {
            yield return new WaitForSeconds(1f);
            anim.SetTrigger("KickForward");
            yield return new WaitForSeconds(1f);
            GetComponent<CapsuleCollider>().enabled = true;
        }

        protected override void StartRunningAnimation()
        {
            if (!anim.GetBool("Run")) anim.SetBool("Run", true);
        }

        private void stopMoving()
        {
            anim.SetBool("Run", false);
            anim.SetTrigger("Idle");
            isWalking = false;
            multiplierSpeed = 0f;
            multiplierDirection = 0f;
        }

        private void resetCamera(bool startTimers)
        {
            HideJoystick(startTimers);
            ResetAndDisableJoystick();
            transform.position = new Vector3(transform.position.x, transform.position.y, 80.619f);
            mainCamera.transform.position = new Vector3(transform.position.x + 1.04f, 4.91f, 78.115f);
            mainCamera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}