using UnityEngine;
using System.Collections;
using Globals;

public class ButtonSceneLoad : ButtonSelect {

    public string sceneToLoad;

    protected override void DoubleClickAction()
    {
        Timeout.StopTimers();
        Utilities.LoadScene(sceneToLoad);
    }

    protected override void Update()
    {
        // disable flashing
    }
}
