﻿using UnityEngine;
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

    public static void PlayAudio(AudioSource audioSource, bool shouldSetAsCurrent)
    {
        if (audioSource != null)
        {
            StopAudio(Sound.CurrentPlayingSound);
            if (shouldSetAsCurrent) Sound.CurrentPlayingSound = audioSource;
            audioSource.Play();
        }
    }

    public static void PlayAudio(AudioSource audioToPlay, AudioSource currentAudio)
    {
        if (audioToPlay != null)
        {
            StopAudio(Sound.CurrentPlayingSound);
            Sound.CurrentPlayingSound = audioToPlay;
            Sound.PreviousSound = currentAudio;
            audioToPlay.Play();
        }
    }

    public static void StopAudio(AudioSource audioSource)
    {
        if (audioSource != null && audioSource.isPlaying) audioSource.Stop();
    }

    public static void LoadScene(string sceneToLoad)
    {
        if (sceneToLoad.ToLower().Contains("puzzle"))
        {
            if (!Scenes.CompletedScenes.Contains(Application.loadedLevelName)) Scenes.CompletedScenes.Add(Application.loadedLevelName);
        }
        if (sceneToLoad != "") Application.LoadLevel(sceneToLoad);
    }
}
