using Globals;
using UnityEngine;

public class ButtonSceneLoad : ButtonSelect {

    public string sceneToLoad;
    public bool shouldAskParentPresent = false;
    public bool loadingEmotionScene = true;
    public bool loadPreviousScene = false;

    protected override void DoubleClickAction()
    {
        Timeout.StopTimers();
        if (GameObject.Find("MainCanvas") != null)
            Utilities.StopAudio(GameObject.Find("MainCanvas").GetComponent<AudioSource>());
        if (shouldAskParentPresent)
        {
            Scenes.NextSceneToLoad = sceneToLoad;
            Utilities.LoadScene("ParentPresentMenuScreen");
        }
        else
        {
            if (loadingEmotionScene)
                Utilities.LoadEmotionScene(sceneToLoad);
            else if (loadPreviousScene)
                Utilities.LoadScene(Scenes.GetLastLoadedScene());
            else
                Utilities.LoadScene(sceneToLoad);
        }
    }

    protected override void Update()
    {
        // disable flashing
    }
}
