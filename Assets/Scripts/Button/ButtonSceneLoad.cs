using UnityEngine;
using System.Collections;
using Globals;

public class ButtonSceneLoad : ButtonSelect {

    public string sceneToLoad;

    protected override void DoubleClickAction()
    {
        Timeout.StopTimers();
        if (Tutorials.MainTutorialHasRun)
        {
            Utilities.LoadScene(sceneToLoad);
        }
        else
        {
            Scenes.NextSceneToLoad = sceneToLoad;
            Utilities.LoadScene("Tutorial");
        }
        
    }

    protected override void Update()
    {
        // disable flashing
    }
}
