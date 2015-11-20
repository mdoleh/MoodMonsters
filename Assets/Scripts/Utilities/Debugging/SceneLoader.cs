using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Pause pauseButton;
    public Dropdown scenes;
    public static string sceneToLoad;

    public void LoadScene()
    {
        pauseButton.UnPauseGame();
        Utilities.LoadScene(sceneToLoad);
    }

    public void UpdateSceneToLoad()
    {
        sceneToLoad = scenes.options[scenes.value].text;
    }
}
