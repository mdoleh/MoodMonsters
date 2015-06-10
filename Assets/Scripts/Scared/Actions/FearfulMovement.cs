using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Globals;
using ScaredScene;

public class FearfulMovement : CharacterMovement
{
    public Camera mainCamera;
    public CameraFollow cameraFollow;
    public GameObject joystickCanvas;
    public GameObject[] joystickAnimations;
    protected bool waitingForScarlet = true;
    private GameObject otherCharacter;
    private AudioSource joystickInstructions;
    private GameObject disableJoystickPanel;
    private GameObject disableHelpPanel;
    private Joystick joystickScript;
    private bool trackJoystick = false;
    protected bool joystickInstructionsAlreadyPlayed = false;
    private bool runSpeedFailure = false;
    private AudioSource runSpeedAudio;

    protected override void Start()
    {
        base.Start();
        otherCharacter = GameObject.Find("Scarlet");
        joystickInstructions = GameObject.Find("ControllerCanvas").GetComponent<AudioSource>();
        disableJoystickPanel = GameObject.Find("ControllerCanvas").transform.FindChild("DisablePanel").gameObject;
        disableHelpPanel = GameObject.Find("HelpCanvas").transform.FindChild("DisablePanel").gameObject;
        joystickScript = joystickCanvas.GetComponentInChildren<Joystick>();
        runSpeedAudio = GameObject.Find("ControllerCanvas").transform.FindChild("RunSpeedFailure").GetComponent<AudioSource>();
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
        trackJoystick = false;
        joystickScript.ButtonRelease();
        disableJoystickPanel.SetActive(true);
        multiplierDirection = 0f;
        if (multiplierSpeed < 3f)
        {
            ResetPosition();
        }
        else
        {
            multiplierSpeed = 3f;
            base.RunJump();
            DisableHelpUI();
        }
    }

    private void ResetPosition()
    {
        base.EdgeSlip();
        runSpeedFailure = true;
        Utilities.PlayAudio(runSpeedAudio);
    }

    private void StartJoystickTutorial()
    {
        if (!runSpeedFailure) adjustCamera();
        StartCoroutine(playJoystickInstructions());
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
        trackJoystickMovement();
    }

    private void trackJoystickMovement()
    {
        if (trackJoystick)
        {
            if (joystickScript.CurrentSpeedAndDirection.y > 0) base.Run();
            multiplierSpeed = joystickScript.CurrentSpeedAndDirection.y;
            multiplierDirection = joystickScript.CurrentSpeedAndDirection.x;
            // limit character's position laterally (z-direction)
            if (transform.position.z > 167.374f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 167.374f);
            }
            else if (transform.position.z < 166.987f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 166.987f);
            }
            // limit character's position so it can't move behind the camera
            if (Math.Abs(mainCamera.transform.position.x - transform.position.x) < 1.0f)
            {
                transform.position = new Vector3(mainCamera.transform.position.x + 1.0f, transform.position.y, transform.position.z);
            }
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
        EnableHelpUI();
        GUIDetect.NextGUI();
    }

    public void BackAway()
    {
        anim.SetTrigger("BackAway");
        multiplierSpeed = -0.2f;
        StartWalking();
    }

    public override void EdgeSlip()
    {
        resetCamera();
        runSpeedFailure = false;
        trackJoystick = false;
        multiplierDirection = 0f;
        base.EdgeSlip();
    }

    protected virtual void adjustCamera()
    {
        cameraFollow.enabled = false;
        if (GUIDetect.GetGUIByName(GUIDetect.CanvasList[0]).enabled)
        {
            GUIDetect.NextGUI();
        }
        else
        {
            joystickCanvas.GetComponent<Canvas>().enabled = true;
        }
        mainCamera.transform.position = new Vector3(transform.position.x - 1.0f, transform.position.y + 3.0f, transform.position.z + 0.3f);
        mainCamera.transform.localRotation = Quaternion.Euler(33.56473f, 98.39697f, 5.486476f);
    }

    private void resetCamera()
    {
        cameraFollow.enabled = true;
        joystickCanvas.GetComponent<Canvas>().enabled = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, 167.147f);
        mainCamera.transform.position = new Vector3(cameraFollow.gameObject.transform.position.x, 6.95f, 163.25f);
        mainCamera.transform.localRotation = Quaternion.Euler(4.587073f, 1.254006f, 0.08177387f);
    }

    private void enableJoystick()
    {
        handleRunSpeedFailure();
        disableJoystickPanel.SetActive(false);
        trackJoystick = true;
        EnableHelpUI();
        Timeout.SetRepeatAudio(joystickInstructions);
        multiplierSpeed = 0f;
        multiplierDirection = 0f;
        isWalking = true;
    }

    private void handleRunSpeedFailure()
    {
        if (runSpeedFailure)
        {
            StopWalking(false);
            runSpeedFailure = false;
        }
    }

    private IEnumerator playJoystickInstructions()
    {
        if (!joystickInstructionsAlreadyPlayed)
        {
            foreach (var joystickAnimation in joystickAnimations)
            {
                joystickAnimation.SetActive(true);
                var audio = joystickAnimation.GetComponent<AudioSource>();
                Utilities.PlayAudio(audio);
                yield return new WaitForSeconds(audio.clip.length);
                joystickAnimation.SetActive(false);
            }
            joystickInstructionsAlreadyPlayed = true;
        }
        enableJoystick();
    }

    protected void EnableHelpUI()
    {
        disableHelpPanel.SetActive(false);
    }

    protected void DisableHelpUI()
    {
        disableHelpPanel.SetActive(true);
    }
}
