using System;
using System.Collections;
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
        private bool isBackingAway = false;
        private bool shouldPlayJoystickAudio = false;
        private AudioSource runSpeedAudio;
        private AudioSource edgeSlipAudio;
        private GameObject currentParent;
        private RigidbodyConstraints originalConstraints;

        protected override void Start()
        {
            base.Start();
            otherCharacter = GameObject.Find("Scarlet");
            runSpeedAudio = joystickCanvas.transform.FindChild("RunSpeedFailure").GetComponent<AudioSource>();
            edgeSlipAudio = transform.FindChild("Dialogue").FindChild("Whoa").GetComponent<AudioSource>();
            currentParent = parentCharacters.ToList().First(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()));
        }

        public override void StartRunningAnimation()
        {
            base.Run();
        }

        public void RunJumpWithClapping()
        {
            RunJump();
            if (GameFlags.AdultIsPresent)
            {
                currentParent.GetComponent<Clapping>().StartClapping();
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
                if (shouldPlayJoystickAudio)
                {
                    Timeout.StopTimers();
                    shouldPlayJoystickAudio = false;
                    StartCoroutine(playJoystickAudio());
                }
            }
            else
            {
                StopWalking(false);
            }
        }

        private IEnumerator playJoystickAudio()
        {
            if (Sound.CurrentPlayingSound == runSpeedAudio)
            {
                while (Sound.CurrentPlayingSound.isPlaying)
                {
                    yield return new WaitForSeconds(0.01f);
                }
            }
            Utilities.PlayAudio(Timeout.GetRepeatAudio());
            yield return new WaitForSeconds(Timeout.GetRepeatAudio().clip.length);
            Timeout.StartTimers();
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

        public void JumpToRunWithAudio()
        {
            base.JumpToRun();
            Utilities.PlayRandomAudio(transform.FindChild("SuccessAudio").GetComponentsInChildren<AudioSource>());
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
            shouldPlayJoystickAudio = true;
        }

        public override void ShiftIdle()
        {
            if (runSpeedFailure) return;
            if (!isBackingAway) return;
            isBackingAway = false;
            StopWalking(false);
            base.ShiftIdle();
            joystickCanvas.GetComponent<Canvas>().enabled = true;
            EnableHelpGUI();
            GUIHelper.NextGUI();
        }

        public void BackAway()
        {
            isBackingAway = true;
            anim.SetTrigger("BackAway");
            multiplierSpeed = -0.2f;
            StartWalking();
        }

        public override void EdgeSlip(string stumbleTrigger)
        {
            resetCamera();
            cameraFollow.enabled = false;
            DisableHelpGUI();
            runSpeedFailure = false;
            trackJoystick = false;
            multiplierDirection = 0f;
            Utilities.PlayAudio(edgeSlipAudio);
            base.EdgeSlip(stumbleTrigger);
        }

        private void AdjustCamera()
        {
            cameraFollow.enabled = false;
            if (!joystickCanvas.activeInHierarchy) GUIHelper.NextGUI();
            joystickCanvas.GetComponent<Canvas>().enabled = true;
            mainCamera.transform.position = new Vector3(transform.position.x - 1.0f, transform.position.y + 3.0f, transform.position.z + 0.3f);
            mainCamera.transform.localRotation = Quaternion.Euler(33.56473f, 98.39697f, 5.486476f);
        }

        private void resetCamera()
        {
            cameraFollow.enabled = true;
            HideJoystick(true);
            transform.position = new Vector3(transform.position.x, transform.position.y, 167.147f);
            mainCamera.transform.position = new Vector3(cameraFollow.gameObject.transform.position.x - 0.6189f, 6.95f, 162.82f);
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