using System.Collections.Generic;

public class SadTutorial : TutorialBase
{
    protected override void HelpExplanationComplete()
    {
        base.HelpExplanationComplete();
        GUIDetect.CanvasList = new List<string>
        {
            "TutorialCanvas", "ControllerCanvas", "EmotionsCanvas", "PhysicalCanvas1", "PhysicalCanvas2", "PhysicalCanvas3", "ActionsCanvas"
        };
        GUIDetect.AudioIgnoreList = new List<string> { "ControllerCanvas" };
    }

    protected override void InitializeGameObjects()
    {
        base.InitializeGameObjects();
    }

    protected override void InitializeAudio()
    {
        base.InitializeAudio();
    }
}