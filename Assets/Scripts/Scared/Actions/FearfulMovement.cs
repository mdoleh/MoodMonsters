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

    public void ShiftScared()
    {
        anim.SetTrigger("Scared");
        GUIDetect.NextGUI();
    }
}
