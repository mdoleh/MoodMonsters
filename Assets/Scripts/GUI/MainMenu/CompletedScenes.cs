using System.Collections;
using Globals;
using UnityEngine;
using UnityEngine.UI;

// Updates the Main Menu to show which scenes are already completed
public class CompletedScenes : MonoBehaviour
{
    public GameObject bonusScene;
    public AudioSource initialAudio;

    private void Start()
    {
        ShowCompletedScenes();
        Utilities.PlayAudio(GameObject.Find("IntroAudio").GetComponent<AudioSource>());
        Timeout.StartTimers();
        Timeout.SetRepeatAudio(GameObject.Find("IntroAudio").GetComponent<AudioSource>());
    }

    private void ShowCompletedScenes()
    {
        foreach (var scene in Scenes.CompletedScenes)
        {
            var completedScene = GameObject.Find(scene);
            if (completedScene != null)
            {
                completedScene.GetComponent<Button>().enabled = false;
                completedScene.GetComponent<ButtonSceneLoad>().enabled = false;
                completedScene.transform.FindChild("Checkmark").gameObject.SetActive(true);
                completedScene.transform.FindChild("Text").GetComponent<RawImage>().color = new Color(0.66f, 0.66f, 0.66f, 1f);
            }
        }
        StartCoroutine(showBonusScene());
    }

    private IEnumerator showBonusScene()
    {
        if (!Scenes.HasCompletedAllScenes()) yield break;
        yield return new WaitForSeconds(initialAudio.clip.length);
        bonusScene.SetActive(true);
        var bonusAudio = bonusScene.GetComponent<AudioSource>();
        Utilities.PlayAudio(bonusAudio);
        yield return new WaitForSeconds(bonusAudio.clip.length);
    }
}
