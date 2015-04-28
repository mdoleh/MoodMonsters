using System;
using UnityEngine;
using System.Collections;
using ScaredScene;

public class FearfulMovement : CharacterMovement
{
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
}
