using System.Collections;
using Globals;
using ScaredScene;
using UnityEngine;
using UnityEngine.UI;

public class ScaredTutorial : TutorialBase
{
    public GameObject scarlet;

    protected override void HelpExplanationComplete()
    {
        scarlet.GetComponent<CharacterMovement>().StartTurning();
    }
}