using System.Collections;
using System.Collections.Generic;
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
        base.HelpExplanationComplete();
        GUIHelper.CanvasList = new List<string>
        {
            "TutorialCanvas", "ControllerCanvas", "EmotionsCanvas", "PhysicalCanvas1", "PhysicalCanvas2", "PhysicalCanvas3", "ActionsCanvas"
        };
        GUIHelper.AudioIgnoreList = new List<string>{ "ControllerCanvas" };

        scarlet.GetComponent<CharacterMovement>().StartSequence();
        aj.GetComponent<CharacterMovement>().StartSequence();
    }
}