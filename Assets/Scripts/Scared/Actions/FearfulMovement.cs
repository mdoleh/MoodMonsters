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
    public TutorialBase tutorial;
    public GameObject[] joystickAnimations;
    private bool waitingForScarlet = true;
    private GameObject otherCharacter;
    private AudioSource joystickInstructions;
    private GameObject disablePanel;
    private Joystick joystickScript;
    private bool trackJoystick = false;
    private bool joystickInstructionsAlreadyPlayed = true;
    private bool runSpeedFailure = false;
    private AudioSource runSpeedAudio;

    protected override void Start()
    {
        base.Start();
        otherCharacter = GameObject.Find("Scarlet");
        joystickInstructions = GameObject.Find("ControllerCanvas").GetComponent<AudioSource>();
        disablePanel = GameObject.Find("ControllerCanvas").transform.FindChild("DisablePanel").gameObject;
        joystickScript = joystickCanvas.GetComponentInChildren<Joystick>();
        runSpeedAudio = GameObject.Find("ControllerCanvas").transform.FindChild("RunSpeedFailure").GetComponent<AudioSource>();
    }

    public override void StartSequence()
    {
        anim.SetTrigger("Idle");
    }

    public override void Run()
    {
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

    public override void RunJump()
    {
        trackJoystick = false;
        joystickScript.ButtonRelease();
        disablePanel.SetActive(true);
        multiplierDirection = 0f;
        if (multiplierSpeed < 3f)
        {
            ResetPosition();
        }
        else
        {
            multiplierSpeed = 3f;
            base.RunJump();
            tutorial.DisableHelpUI();
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
        StartCoroutine(PlayJoystickInstructions());
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

    protected override void Update()
    {
        base.Update();
        if (Math.Abs(transform.position.x - otherCharacter.transform.position.x) <= 1f)
        {
            StopWalking(true);
        }
        if (trackJoystick)
        {
            if (joystickScript.CurrentSpeedAndDirection.y > 0) base.Run();
            multiplierSpeed = joystickScript.CurrentSpeedAndDirection.y;
            multiplierDirection = joystickScript.CurrentSpeedAndDirection.x;
            if (transform.position.z > 167.374f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 167.374f);
            } 
            else if (transform.position.z < 166.987f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 166.987f);
            }
            if (Math.Abs(mainCamera.transform.position.x - transform.position.x) < 1.5f)
            {
                transform.position = new Vector3(mainCamera.transform.position.x + 1.5f, transform.position.y, transform.position.z);
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
        tutorial.EnableHelpGUI();
        GUIDetect.NextGUI();
    }

    public void BackAway()
    {
        //RevertPositionForEdgeSlip();
        anim.SetTrigger("BackAway");
        multiplierSpeed = (float)-0.2;
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

    private void RevertPositionForEdgeSlip()
    {
        var center = GetComponent<BoxCollider>().center;
        GetComponent<BoxCollider>().center = new Vector3(center.x, 0.9f, center.z);
        transform.position = new Vector3(transform.position.x, 5.48f, transform.position.z);
    }

    private void adjustCamera()
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
        mainCamera.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y + 3.5f, transform.position.z + 0.3f);
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

    private IEnumerator PlayJoystickInstructions()
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
        if (runSpeedFailure)
        {
            StopWalking(false);
            runSpeedFailure = false;
        }
        disablePanel.SetActive(false);
        trackJoystick = true;
        tutorial.EnableHelpGUI();
        Timeout.SetRepeatAudio(joystickInstructions);
        multiplierSpeed = 0f;
        multiplierDirection = 0f;
        isWalking = true;
    }
}
