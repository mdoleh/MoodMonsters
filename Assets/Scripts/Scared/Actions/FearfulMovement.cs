using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScaredScene;

public class FearfulMovement : CharacterMovement
{
    public Camera mainCamera;
    public CameraFollow cameraFollow;
    public GameObject joystickCanvas;
    public TutorialBase tutorial;
    private bool waitingForScarlet = true;
    private GameObject otherCharacter;
    private IList<AudioSource> joystickInstructions;
    private GameObject disablePanel;
    private Joystick joystickScript;
    private bool trackJoystick = false;
    private bool joystickInstructionsAlreadyPlayed = false;
    private AudioSource runSpeedAudio;

    protected override void Start()
    {
        base.Start();
        otherCharacter = GameObject.Find("Scarlet");
        joystickInstructions = GameObject.Find("ControllerCanvas").transform.FindChild("Instructions").GetComponentsInChildren<AudioSource>().ToList();
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
        if (!waitingForScarlet)
        {
            anim.speed = 1f;
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
        disablePanel.SetActive(true);
        if (multiplier < 3f)
        {
            ResetPosition();
        }
        else
        {
            multiplier = 3f;
            base.RunJump();    
        }
    }

    private void ResetPosition()
    {
        base.EdgeSlip();
        multiplier = -1f;
        anim.speed = -1f;
        Utilities.PlayAudio(runSpeedAudio);
    }

    private void StartJoystickTutorial()
    {
        adjustCamera();
        StartCoroutine(PlayJoystickInstructions());
    }

    private void StopWalking(bool waitForScarlet)
    {
        if (waitForScarlet) resetCamera();
        anim.SetTrigger("Idle");
        anim.SetBool("Walking", false);
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
            multiplier = joystickScript.CurrentSpeedAndDirection.y;
        }
    }

    public override void ShiftIdle()
    {
        StopWalking(false);
        base.ShiftIdle();
        tutorial.EnableHelpGUI();
        GUIDetect.NextGUI();
    }

    public void BackAway()
    {
        //RevertPositionForEdgeSlip();
        anim.SetTrigger("BackAway");
        multiplier = (float)-0.2;
        StartWalking();
    }

    public override void EdgeSlip()
    {
        resetCamera();
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
        joystickCanvas.GetComponent<Canvas>().enabled = true;
        mainCamera.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y + 3.5f, transform.position.z + 0.3f);
        mainCamera.transform.localRotation = Quaternion.Euler(33.56473f, 98.39697f, 5.486476f);
    }

    private void resetCamera()
    {
        cameraFollow.enabled = true;
        joystickCanvas.GetComponent<Canvas>().enabled = false;
        mainCamera.transform.position = new Vector3(cameraFollow.gameObject.transform.position.x, 6.95f, 163.25f);
        mainCamera.transform.localRotation = Quaternion.Euler(4.587073f, 1.254006f, 0.08177387f);
    }

    private IEnumerator PlayJoystickInstructions()
    {
        if (!joystickInstructionsAlreadyPlayed)
        {
            foreach (var instruction in joystickInstructions)
            {
                Utilities.PlayAudio(instruction);
                yield return new WaitForSeconds(instruction.clip.length);
            }
            joystickInstructionsAlreadyPlayed = true;
        }
        disablePanel.SetActive(false);
        trackJoystick = true;
        isWalking = true;
        base.Run();
    }
}
