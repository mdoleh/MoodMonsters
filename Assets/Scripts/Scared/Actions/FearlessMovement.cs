using UnityEngine;
using System.Collections;
using ScaredScene;

public class FearlessMovement : CharacterMovement
{
    private GameObject otherCharacter;

    protected override void Start()
    {
        base.Start();
        otherCharacter = GameObject.Find("Aj");
    }

    public override void TurnRight()
    {
        otherCharacter.GetComponent<CharacterMovement>().JumpToRun();
        base.TurnRight();
    }

    public override void StartWalking()
    {
        base.StartWalking();
        otherCharacter.GetComponent<CharacterMovement>().StartWalking();
    }

    public override void TurnAround()
    {
        base.TurnAround();
        otherCharacter.GetComponent<CharacterMovement>().Run();
    }

    public override void Run()
    {
        base.Run();
        otherCharacter.GetComponent<CharacterMovement>().StartWalking();
    }

    protected override void Update()
    {
        base.Update();
        if (isWalking)
        {
            if (transform.position.z < 166.6f)
            {
                JumpDown();
            }
        }
    }
}
