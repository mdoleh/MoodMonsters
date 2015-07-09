using System.Collections.Generic;

public class SadTutorial : TutorialBase
{
    

    protected override void HelpExplanationComplete()
    {
        base.HelpExplanationComplete();
        GUIDetect.CanvasList = new List<string>
        {
            "TutorialCanvas", "EmotionsCanvas", "PhysicalCanvas1", "PhysicalCanvas2", "PhysicalCanvas3", "ActionsCanvas"
        };
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