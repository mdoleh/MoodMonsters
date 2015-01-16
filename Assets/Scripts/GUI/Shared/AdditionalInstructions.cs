using UnityEngine;
using System.Collections;

public class AdditionalInstructions : MonoBehaviour
{

    private AudioSource additionalInstructions;
    private AudioSource initalInstructions;
    private Canvas canvas;

    private bool playedOnce = false;

    private void Awake()
    {
        additionalInstructions = transform.Find("AdditionalInstructions").GetComponent<AudioSource>();
        initalInstructions = GetComponent<AudioSource>();
        canvas = GetComponent<Canvas>();
    }

    void Update () {
        if (!playedOnce && !initalInstructions.isPlaying && canvas.enabled)
        {
            playedOnce = true;
            Utilities.PlayAudio(additionalInstructions);
        }
	}
}
