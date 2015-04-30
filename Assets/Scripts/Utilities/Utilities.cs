using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public static void PauseAudio(AudioSource audioSource)
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public static void UnPauseAudio(AudioSource audioSource)
    {
        if (audioSource != null && Sound.CurrentPlayingSound == audioSource && !audioSource.isPlaying)
        {
            audioSource.UnPause();
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

    public static AudioSource PlayRandomAudio(IList<AudioSource> audioSources)
    {
        var audioToPlay = audioSources[Random.Range(0, audioSources.Count())];
        PlayAudio(audioToPlay);
        return audioToPlay;
    }
}
