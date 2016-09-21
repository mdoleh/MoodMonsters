using UnityEngine;

// Loads a scene after scrolling has completed
// Used on the End Screen by the Credits
public class LoadScene : EndScrollAction
{
    public string SceneToLoad;
    private bool beenTriggered = false;

    public override void AfterScrollCompleted(Transform self, Vector3 originalPosition)
    {
        if (!beenTriggered)
        {
            Utilities.LoadScene(SceneToLoad);
            beenTriggered = true;
        }
    }
}
