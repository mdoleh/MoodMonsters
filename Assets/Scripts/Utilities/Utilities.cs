using UnityEngine;
using System.Collections;
using Globals;

public class Utilities : MonoBehaviour {

    public static void PlayAudio(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            StopAudio(Sound.CurrentPlayingSound);
            Sound.CurrentPlayingSound = audioSource;
            audioSource.Play();
        }
    }

    public static void StopAudio(AudioSource audioSource)
    {
        if (audioSource != null && audioSource.isPlaying) audioSource.Stop();
    }

    public static void LoadScene(string sceneToLoad)
    {
        if (sceneToLoad.ToLower().Contains("minigame"))
        {
            var sceneName = Application.loadedLevelName.Replace("ActionsMenu", "");
            if (!Scenes.CompletedScenes.Contains(sceneName)) Scenes.CompletedScenes.Add(sceneName);
        }
        if (sceneToLoad != "") Application.LoadLevel(sceneToLoad);
    }
}
