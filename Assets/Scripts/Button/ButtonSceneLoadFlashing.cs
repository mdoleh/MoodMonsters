using Globals;

public class ButtonSceneLoadFlashing : ButtonSelect {

    public string sceneToLoad;

    protected override void DoubleClickAction()
    {
        Scenes.NextSceneToLoad = "IntroductionScreen";
        Utilities.LoadScene(sceneToLoad);
    }
}
