using System;
using UnityEngine;
using System.Collections;
using ScaredScene;

public class FearfulMovement : CharacterMovement
{
    public Camera mainCamera;
    public CameraFollow cameraFollow;
    public GameObject joystick;
    public TutorialBase tutorial;
    private bool waitingForScarlet = true;
    private GameObject otherCharacter;
    private GameObject nextGUI;

    protected override void Start()
    {
        base.Start();
        otherCharacter = GameObject.Find("Scarlet");
    }

    public override void StartSequence()
    {
        anim.SetTrigger("Idle");
    }

    public override void Run()
    {
        adjustCamera();
        if (!waitingForScarlet)
        {
            isWalking = true;
            base.Run();
        }
        else
        {
            StopWalking(false);
        }
    }

    private void StopWalking(bool waitForScarlet)
    {
        resetCamera();
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
        RevertPositionForEdgeSlip();
        anim.SetTrigger("BackAway");
        multiplier = (float)-0.2;
        StartWalking();
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
        joystick.GetComponent<Canvas>().enabled = true;
        mainCamera.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y + 3.5f, transform.position.z + 0.3f);
        mainCamera.transform.localRotation = Quaternion.Euler(33.56473f, 98.39697f, 5.486476f);
    }

    private void resetCamera()
    {
        cameraFollow.enabled = true;
        joystick.GetComponent<Canvas>().enabled = false;
        mainCamera.transform.position = new Vector3(cameraFollow.gameObject.transform.position.x, 6.95f, 163.25f);
        mainCamera.transform.localRotation = Quaternion.Euler(4.587073f, 1.254006f, 0.08177387f);
    }
}
