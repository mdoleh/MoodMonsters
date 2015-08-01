using Globals;

public class ButtonSceneLoad : ButtonSelect {

    public string sceneToLoad;
    public bool shouldAskParentPresent = false;

    protected override void DoubleClickAction()
    {
        Timeout.StopTimers();
        if (string.IsNullOrEmpty(sceneToLoad)) return;
        if (shouldAskParentPresent)
        {
            Scenes.NextSceneToLoad = sceneToLoad;
            Utilities.LoadScene("ParentPresentMenuScreen");
        }
        Utilities.LoadEmotionScene(sceneToLoad);
    }

    protected override void Update()
    {
        // disable flashing
    }
}
