using UnityEngine;
using System.Collections;
using ScaredScene;

public class FearfulMovement : CharacterMovement
{
    public bool shouldRun = false;
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
        if (shouldRun)
        {
            isWalking = true;
            base.Run();
        }
        else
        {
            anim.SetTrigger("Idle");
            isWalking = false;
            shouldRun = true;
        }
    }
}
