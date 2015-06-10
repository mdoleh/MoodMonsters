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

//    public override void TurnRight()
//    {
//        StartCoroutine(DelayTurnRight());
//        base.TurnRight();
//    }

//    private IEnumerator DelayTurnRight()
//    {
//        yield return new WaitForSeconds(0.5f);
//        otherCharacter.GetComponent<CharacterMovement>().TurnRight();
//    }

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
}
