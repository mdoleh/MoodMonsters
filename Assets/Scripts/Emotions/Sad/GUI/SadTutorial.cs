using System.Collections.Generic;
using Globals;
using SadScene;
using UnityEngine;

public class SadTutorial : TutorialBase
{
    public GameObject luis;

    protected override void HelpExplanationComplete()
    {
        base.HelpExplanationComplete();
        GUIHelper.CanvasList = GameFlags.AdultIsPresent
            ? new List<string>
            {
                "TutorialCanvas",
                "ControllerCanvas",
                "EmotionsCanvas",
                "PhysicalCanvas1",
                "PhysicalCanvas2",
                "PhysicalCanvas3",
                "EmotionActionsCanvas",
                "ParentActionsCanvas",
                "SituationActionsCanvas"
            }
            : new List<string>
            {
                "TutorialCanvas",
                "ControllerCanvas",
                "EmotionsCanvas",
                "PhysicalCanvas1",
                "PhysicalCanvas2",
                "PhysicalCanvas3",
                "EmotionActionsCanvas",
                "ParentDefaultCanvas", 
                "SituationActionsCanvas"
            };
        GUIHelper.AudioIgnoreList = new List<string> { "ControllerCanvas" };
        GUIHelper.HelpCanvasIgnoreList = new List<string> { "ParentDefaultCanvas" };
        luis.GetComponent<OutsideGroupSoccerAnimation>().KickForward();
    }
}