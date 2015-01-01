using UnityEngine;
using System.Collections;

public class ButtonSceneLoad : ButtonSelect {

    public string sceneToLoad;

    protected override void DoubleClickAction()
    {
        Utilities.LoadScene(sceneToLoad);
    }
}
