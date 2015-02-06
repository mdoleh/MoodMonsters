using UnityEngine;
using System.Collections;
using Globals;

public class ButtonSceneLoad : ButtonSelect {

    public string sceneToLoad;
    public string tutorialToLoad;

    protected override void DoubleClickAction()
    {
        Timeout.StopTimers();
        if (sceneToLoad == "") return;
        if (Tutorials.MainTutorialHasRun || tutorialToLoad == "")
        {
            Utilities.LoadScene(sceneToLoad);
        }
        else
        {
            Scenes.NextSceneToLoad = sceneToLoad;
            Utilities.LoadScene(tutorialToLoad);
        }
    }

    protected override void Update()
    {
        // disable flashing
    }
}
