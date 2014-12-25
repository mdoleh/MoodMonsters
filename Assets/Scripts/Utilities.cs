using UnityEngine;
using System.Collections;

public class Utilities : MonoBehaviour {

    public static void PlayAudio(AudioSource audioSource)
    {
        if (audioSource != null) audioSource.Play();
    }
}
