using UnityEngine;
using System.Collections;
using ScaredScene;

public class FearfulMovement : CharacterMovement {

    public override void StartSequence()
    {
        anim.SetTrigger("Idle");
    }
}
