using System.Collections;
using Globals;
using ScaredScene;
using UnityEngine;
using UnityEngine.UI;

public class ScaredTutorial : TutorialBase
{
    public GameObject scarlet;
    public GameObject aj;

    protected override void HelpExplanationComplete()
    {
        scarlet.GetComponent<CharacterMovement>().StartSequence();
        aj.GetComponent<CharacterMovement>().StartSequence();
    }
}