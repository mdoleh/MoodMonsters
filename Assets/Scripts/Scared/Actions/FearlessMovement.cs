﻿using UnityEngine;
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
}
