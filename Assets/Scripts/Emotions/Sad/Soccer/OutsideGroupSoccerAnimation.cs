﻿using System;
using UnityEngine;
using System.Collections;
using Globals;

namespace SadScene
{
    public class OutsideGroupSoccerAnimation : ControllerMovement
    {
        public OutsideGroupSoccerBallMovement soccerBall;
        public AudioSource didntKickHardEnough;
        public ObjectSequenceManager retryPointManager;
        
        private Animator anim;
        private bool shouldAdjustCamera = true;
        private bool shouldKickUp = true;

        protected virtual void Start()
        {
            base.Start();
            anim = GetComponent<Animator>();
        }

        public void SetSoccerBallFlag(bool flag)
        {
            soccerBall.isWatching = flag;
        }

        public void HideSoccerBall()
        {
            soccerBall.gameObject.SetActive(false);
        }

        public void SetWalkAwaySpeed(bool walking, float speed, float direction)
        {
            isWalking = walking;
            multiplierSpeed = speed;
            multiplierDirection = direction;
        }

        public void ShiftIdle()
        {
            anim.SetTrigger("Idle");
            if (!shouldAdjustCamera) return;
            AdjustCamera();
            StartJoystickTutorial();
        }

        public void KickBallUp()
        {
            if (shouldKickUp) soccerBall.KickBallUp();
        }

        public void KickForwardWithDelay()
        {
            shouldKickUp = false;
            anim.SetTrigger("Idle");
            StartCoroutine(DelayKickForward());
        }

        private IEnumerator DelayKickForward()
        {
            yield return new WaitForSeconds(0.5f);
            KickForward();
            shouldKickUp = true;
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
            anim.SetTrigger("Idle");
            resetCamera(false);
            Timeout.StopTimers();
            GetComponent<OutsideGroupDialogue>().StartDialogue();
        }

        public void KickForwardEvent()
        {
            if (multiplierSpeed < 2f)
            {
                soccerBall.KickBallForward(multiplierSpeed / 3f);
                resetPosition();
            }
            else
            {
                soccerBall.KickBallForward(multiplierSpeed / 2f);
            }
        }

        private void resetPosition()
        {
            retryPointManager.NextInSequence();
            Utilities.PlayAudio(didntKickHardEnough);
            anim.SetTrigger("WalkBackwards");
            shouldAdjustCamera = false;
        }

        public void WalkBackwardsEvent()
        {
            if (shouldAdjustCamera) return;
            isWalking = true;
            multiplierSpeed = -1f;
            multiplierDirection = 0f;
        }

        private IEnumerator KickBallForward()
        {
            anim.SetTrigger("KickForward");
            yield return new WaitForSeconds(2f);
            GetComponent<CapsuleCollider>().enabled = true;
        }

        protected override void StartRunningAnimation()
        {
            if (!anim.GetBool("Run")) anim.SetBool("Run", true);
        }

        public void StopWalkingBackwards()
        {
            isWalking = false;
            multiplierSpeed = 0f;
            shouldAdjustCamera = true;
            ShiftIdle();
        }

        private void stopMoving()
        {
            anim.SetBool("Run", false);
            isWalking = false;
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