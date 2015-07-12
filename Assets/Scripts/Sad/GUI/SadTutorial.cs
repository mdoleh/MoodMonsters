using System.Collections.Generic;
using SadScene;
using UnityEngine;

public class SadTutorial : TutorialBase
{
    public GameObject luis;

    protected override void HelpExplanationComplete()
    {
        base.HelpExplanationComplete();
        GUIDetect.CanvasList = new List<string>
        {
            "TutorialCanvas", "ControllerCanvas", "EmotionsCanvas", "PhysicalCanvas1", "PhysicalCanvas2", "PhysicalCanvas3", "ActionsCanvas"
        };
        GUIDetect.AudioIgnoreList = new List<string> { "ControllerCanvas" };
        luis.GetComponent<OutsideGroupSoccerAnimation>().KickForward();
    }
}