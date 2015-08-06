using System;
using System.Linq;
using Globals;
using ScaredScene;
using UnityEngine;

namespace ScaredScene
{
    public class FearfulMovement : CharacterMovement
    {
        public CameraFollow cameraFollow;
        public GameObject[] parentCharacters;

        protected bool waitingForScarlet = true;

        private GameObject otherCharacter;
        private bool runSpeedFailure = false;
        private AudioSource runSpeedAudio;
        private GameObject currentParent;

        protected override void Start()
        {
            base.Start();
            otherCharacter = GameObject.Find("Scarlet");
            runSpeedAudio =
                GameObject.Find("ControllerCanvas").transform.FindChild("RunSpeedFailure").GetComponent<AudioSource>();
            currentParent =
                parentCharacters.ToList().First(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()));
        }

        protected override void StartRunningAnimation()
        {
            base.Run();
        }

        public void RunJumpWithClapping()
        {
            RunJump();
            if (GameFlags.AdultIsPresent)
            {
                currentParent.GetComponent<Comfort>().StartClapping();
            }
            else
            {
                otherCharacter.GetComponent<FearlessMovement>().StartClapping();
            }
        }

        public override void StartSequence()
        {
            anim.SetTrigger("Idle");
        }

        public override void Run()
        {
            if (anim.GetBool("RunAway")) return;
            if (trackJoystick) return;
            if (!waitingForScarlet)
            {
                if (anim.GetBool("WalkBackwards")) StopWalking(false);
                StartJoystickTutorial();
            }
            else
            {
                StopWalking(false);
            }
        }

        public override void StepForward()
        {
            anim.SetBool("TurnRight", false);
            base.StepForward();
        }

        public override void RunJump()
        {
            ResetAndDisableJoystick();
            multiplierDirection = 0f;
            if (multiplierSpeed < 3f)
            {
                ResetPosition();
            }
            else
            {
                multiplierSpeed = 3f;
                base.RunJump();
                DisableHelpGUI();
            }
        }

        private void ResetPosition()
        {
            if (runSpeedFailure) return;
            base.EdgeSlip("StumbleWalkAway");
            runSpeedFailure = true;
            Utilities.PlayAudio(runSpeedAudio);
        }

        protected override void StartJoystickTutorial()
        {
            if (!runSpeedFailure) AdjustCamera();
            base.StartJoystickTutorial();
        }

        private void StopWalking(bool waitForScarlet)
        {
            if (waitForScarlet) resetCamera();
            anim.SetTrigger("Idle");
            anim.SetBool("Walking", false);
            anim.SetBool("WalkBackwards", false);
            isWalking = false;
            waitingForScarlet = waitForScarlet;
        }

        public override void JumpToRun()
        {
            base.JumpToRun();
            otherCharacter.GetComponent<CharacterMovement>().StartSequence();
        }

        public override void TurnAround()
        {
            // do nothing
        }

        public void RunReverse()
        {
            multiplierSpeed = -3f;
            StartWalking();
        }

        protected override void Update()
        {
            base.Update();
            if (Math.Abs(transform.position.x - otherCharacter.transform.position.x) <= 1f)
            {
                StopWalking(true);
            }
        }

        public void WalkBackwards()
        {
            multiplierSpeed = -1f;
            multiplierDirection = 0f;
            anim.SetBool("WalkBackwards", true);
            isWalking = true;
        }

        public override void ShiftIdle()
        {
            if (runSpeedFailure) return;
            StopWalking(false);
            base.ShiftIdle();
            joystickCanvas.GetComponent<Canvas>().enabled = true;
            EnableHelpGUI();
            GUIHelper.NextGUI();
        }

        public void BackAway()
        {
            anim.SetTrigger("BackAway");
            multiplierSpeed = -0.2f;
            StartWalking();
        }

        public override void EdgeSlip(string stumbleTrigger)
        {
            resetCamera();
            runSpeedFailure = false;
            trackJoystick = false;
            multiplierDirection = 0f;
            base.EdgeSlip(stumbleTrigger);
        }

        protected override void AdjustCamera()
        {
            cameraFollow.enabled = false;
            base.AdjustCamera();
        }

        private void resetCamera()
        {
            cameraFollow.enabled = true;
            HideJoystick(true);
            transform.position = new Vector3(transform.position.x, transform.position.y, 167.147f);
            mainCamera.transform.position = new Vector3(cameraFollow.gameObject.transform.position.x, 6.95f, 163.25f);
            mainCamera.transform.localRotation = Quaternion.Euler(4.587073f, 1.254006f, 0.08177387f);
        }

        protected override void EnableJoystick()
        {
            handleRunSpeedFailure();
            base.EnableJoystick();
        }

        private void handleRunSpeedFailure()
        {
            if (runSpeedFailure)
            {
                StopWalking(false);
                runSpeedFailure = false;
            }
        }
    }
}