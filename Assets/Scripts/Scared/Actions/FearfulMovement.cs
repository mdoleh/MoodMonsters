using System;
using UnityEngine;
using System.Collections;
using ScaredScene;

public class FearfulMovement : CharacterMovement
{
    public bool waitingForScarlet = true;
    private GameObject otherCharacter;

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
        isWalking = false;
        waitingForScarlet = waitForScarlet;
    }

    public override void JumpToRun()
    {
        base.JumpToRun();
        otherCharacter.GetComponent<CharacterMovement>().StartSequence();
    }

    protected override void Update()
    {
        base.Update();
        if (Math.Abs(transform.position.x - otherCharacter.transform.position.x) <= 1f)
        {
            StopWalking(true);
        }
    }
}
