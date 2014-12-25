﻿using UnityEngine;
using System.Collections;

public class Utilities : MonoBehaviour {

    public static void PlayAudio(AudioSource audioSource)
    {
        if (audioSource != null) audioSource.Play();
    }

    public static void LoadScene(string sceneToLoad)
    {
        if (sceneToLoad != "") Application.LoadLevel(sceneToLoad);
    }
}
