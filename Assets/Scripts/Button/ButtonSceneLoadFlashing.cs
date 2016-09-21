using Globals;

// Used only by the "Play" button on the Title Screen
public class ButtonSceneLoadFlashing : ButtonSelect {

    public string sceneToLoad;

    protected override void DoubleClickAction()
    {
        Scenes.NextSceneToLoad = "IntroductionScreen";
        Utilities.LoadScene(sceneToLoad);
    }
}
