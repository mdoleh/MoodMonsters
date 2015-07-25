using Globals;

public class ButtonSceneLoad : ButtonSelect {

    public string sceneToLoad;

    protected override void DoubleClickAction()
    {
        Timeout.StopTimers();
        if (sceneToLoad == "") return;
        Utilities.LoadEmotionScene(sceneToLoad);
    }

    protected override void Update()
    {
        // disable flashing
    }
}
