using System.Linq;
using Globals;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Pause pauseButton;
    public Dropdown scenes;
    public Toggle[] flags;
    public Dropdown[] stringFlags;
    public static string sceneToLoad;

    public void Initialize()
    {
        sceneToLoad = Application.loadedLevelName;
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
    }

    public void LoadScene()
    {
        pauseButton.UnPauseGame();
        flags.ToList().ForEach(flag =>
        {
            var field = typeof(GameFlags).GetField(flag.transform.Find("Label").GetComponent<Text>().text);
            field.SetValue(field, flag.isOn);
        });
        typeof(GameFlags).GetFields().ToList().ForEach(field => Debug.Log(field.Name + ": " + field.GetValue(field).ToString()));
        Utilities.LoadScene(sceneToLoad);
    }

    public void UpdateSceneToLoad()
    {
        sceneToLoad = scenes.options[scenes.value].text;
    }
}
