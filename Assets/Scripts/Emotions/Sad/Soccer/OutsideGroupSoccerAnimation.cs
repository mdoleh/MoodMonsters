﻿using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;
using HelpGUI;

namespace SadScene
{
    // Controls interactive movement on Luis as well triggers animations appropriately
    public class OutsideGroupSoccerAnimation : ControllerMovement
    {
        public OutsideGroupSoccerBallMovement soccerBall;
        public AudioSource didntKickHardEnough;
        public ObjectSequenceManager retryPointManager;
        public GameObject runningLanes;
        public Transform[] parents;
        
        private Animator anim;
        private bool shouldAdjustCamera = true;
        private bool shouldKickUp = true;
        private bool shouldMoveParent = true;
        private Transform currentParent;

        protected virtual void Start()
        {
            base.Start();
            anim = GetComponent<Animator>();
            currentParent = parents.ToList().Find(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()));
        }

        public void LockForwardSpeed()
        {
            multiplierDirection = 0f;
            multiplierSpeed = 2f;
            trackJoystick = false;
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
            EnableHelpGUI();
            StartJoystickTutorial();
        }

        private void AdjustCamera()
        {
            if (!joystickCanvas.activeInHierarchy) GUIHelper.NextGUI();
            HelpCanvas.EnableHintButton(false);
            ShowJoystick();
            if (shouldMoveParent) MoveParent();
            mainCamera.transform.position = new Vector3(transform.position.x - 1.0f, transform.position.y + 3.0f, transform.position.z + 0.3f);
            mainCamera.transform.localRotation = Quaternion.Euler(33.56473f, 98.39697f, 5.486476f);
        }

        private void MoveParent()
        {
            currentParent.position = new Vector3(185.86f, 3.9f, 80.425f);
            currentParent.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
            currentParent.gameObject.SetActive(false);
            shouldMoveParent = false;
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
            KickForward(false);
            shouldKickUp = true;
        }

        public void KickForward(bool shouldAdjustPosition)
        {
            LaneAppear.shouldShowLanes = false;
            LaneAppear.HideAllLanes();
            DisableHelpGUI();
            StopMoving();
            ResetCamera(true, shouldAdjustPosition);
            StartCoroutine(KickBallForward());
        }

        public void StartDialogue()
        {
            runningLanes.SetActive(false);
            StopMoving();
            anim.SetTrigger("Idle");
            ResetCamera(false, true);
            Timeout.StopTimers();
            GetComponent<OutsideGroupDialogue>().StartDialogue();
        }

        public void KickForwardEvent()
        {
            if (multiplierSpeed < 2f)
            {
                soccerBall.KickBallForward(multiplierSpeed / 3f);
                ResetPosition(didntKickHardEnough);
            }
            else
            {
                soccerBall.KickBallForward(multiplierSpeed / 2f);
                StartCoroutine(moveLanes());
            }
        }

        private IEnumerator moveLanes()
        {
            yield return new WaitForSeconds(1f);
            runningLanes.transform.position = new Vector3(transform.position.x,
                    runningLanes.transform.position.y, runningLanes.transform.position.z);
        }

        public void ResetPosition(AudioSource audioSource)
        {
            DisableHelpGUI();
            retryPointManager.NextInSequence();
            Utilities.PlayAudio(audioSource);
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

        public override void StartRunningAnimation()
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

        public void StopMoving()
        {
            anim.SetBool("Run", false);
            isWalking = false;
            multiplierDirection = 0f;
        }

        public void ResetCamera(bool startTimers, bool shouldAdjustPosition)
        {
            HideJoystick(startTimers);
            ResetAndDisableJoystick();
            if (shouldAdjustPosition) 
                transform.position = new Vector3(transform.position.x, transform.position.y, soccerBall.transform.position.z);
            mainCamera.transform.position = new Vector3(transform.position.x + 1.04f, 4.91f, transform.position.z - 2.504f);
            mainCamera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}