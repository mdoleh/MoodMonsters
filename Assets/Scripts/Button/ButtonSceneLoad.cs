using Globals;
using UnityEngine;

public class ButtonSceneLoad : ButtonSelect {

    public string sceneToLoad;
    public bool shouldAskParentPresent = false;

    protected override void DoubleClickAction()
    {
        Timeout.StopTimers();
        if (string.IsNullOrEmpty(sceneToLoad)) return;
        Utilities.StopAudio(GameObject.Find("MainCanvas").GetComponent<AudioSource>());
        if (shouldAskParentPresent)
        {
            Scenes.NextSceneToLoad = sceneToLoad;
            Utilities.LoadScene("ParentPresentMenuScreen");
        }
        else
        {
            Utilities.LoadEmotionScene(sceneToLoad);
        }
    }

    protected override void Update()
    {
        // disable flashing
    }
}
