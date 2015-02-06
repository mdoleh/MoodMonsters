using UnityEngine;
using System.Collections;
using Globals;

public class ButtonSceneLoad : ButtonSelect {

    public string sceneToLoad;
    public bool ableToLoadTutorial = true;

    protected override void DoubleClickAction()
    {
        Timeout.StopTimers();
        if (Tutorials.MainTutorialHasRun || !ableToLoadTutorial)
        {
            Utilities.LoadScene(sceneToLoad);
        }
        else
        {
            Scenes.NextSceneToLoad = sceneToLoad;
            Utilities.LoadScene("TutorialWithLily");
        }
        
    }

    protected override void Update()
    {
        // disable flashing
    }
}
