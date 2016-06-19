using System.Collections.Generic;
using System.Linq;
using Globals;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static string DebugCanvasToLoad;
    public Pause pauseButton;
    public Dropdown scenes;
    public Toggle[] flags;
    public Dropdown[] stringFlags;
    public Dropdown lastSceneCompleted;
    public Dropdown canvasToLoad;
    public Toggle simulateAllScenesCompleted;
    private string sceneToLoad;

    public void Initialize()
    {
        sceneToLoad = SceneManager.GetActiveScene().name;
        updateUI();
    }

    private void updateUI()
    {
        flags.ToList().ForEach(flag =>
        {
            var flagText = flag.name;
            var field = typeof(GameFlags).GetField(flagText);
            flag.isOn = (bool)field.GetValue(field);
        });
        stringFlags.ToList().ForEach(flag =>
        {
            var flagText = flag.name;
            var field = typeof(GameFlags).GetField(flagText);
            flag.value = flag.options.FindIndex(x => x.text.Equals((string)field.GetValue(field)));
        });
        lastSceneCompleted.value = lastSceneCompleted.options.FindIndex(x => x.text.Equals(Scenes.GetLastEmotionCompleted()));
        scenes.value = scenes.options.FindIndex(x => x.text.Equals(SceneManager.GetActiveScene().name));
    }

    public void LoadScene()
    {
        pauseButton.UnPauseGame();
        flags.ToList().ForEach(flag =>
        {
            var field = typeof(GameFlags).GetField(flag.name);
            field.SetValue(field, flag.isOn);
        });
        stringFlags.ToList().ForEach(flag =>
        {
            var field = typeof(GameFlags).GetField(flag.name);
            field.SetValue(field, flag.options[flag.value].text);
        });
        Scenes.ResetValues();
        Scenes.LoadingSceneThroughDebugging = true;
        Scenes.CompletedScenes.Add(lastSceneCompleted.options[lastSceneCompleted.value].text);
        Scenes.CompletedScenes = simulateAllScenesCompleted.isOn
            ? new List<string>
            {
                "AngrySceneSmallCity",
                "SadSceneSmallCity",
                "ScaredSceneSmallCity",
                "HappySceneSmallCity"
            }
            : Scenes.CompletedScenes;
        DebugCanvasToLoad = canvasToLoad.options[canvasToLoad.value].text;
        Utilities.LoadScene(sceneToLoad);
    }

    public void UpdateSceneToLoad()
    {
        sceneToLoad = scenes.options[scenes.value].text;
    }
}
