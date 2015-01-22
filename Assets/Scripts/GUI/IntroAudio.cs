using UnityEngine;
using System.Collections;

public class IntroAudio : MonoBehaviour
{
    public int SecondsBetweenRepeat;

    private void Awake()
    {
        StartCoroutine(StartAudio(SecondsBetweenRepeat));
    }

    IEnumerator StartAudio(int seconds)
    {
        while (true)
        {
            Utilities.PlayAudio(audio);
            yield return new WaitForSeconds(seconds);
        }
    }
}
