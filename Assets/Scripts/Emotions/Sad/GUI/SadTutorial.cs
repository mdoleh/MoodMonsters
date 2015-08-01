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
        GUIInitialization.Initialize();
        luis.GetComponent<OutsideGroupSoccerAnimation>().KickForward();
    }
}