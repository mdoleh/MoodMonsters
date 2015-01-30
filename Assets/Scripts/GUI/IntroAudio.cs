using UnityEngine;
using System.Collections;
using Globals;

public class IntroAudio : MonoBehaviour
{
    public int SecondsBetweenRepeat;
    private bool screenClicked = false;

    public void ScreenClicked()
    {
        if (screenClicked) return;
        screenClicked = true;
        StartCoroutine(StartAudio(SecondsBetweenRepeat));
    }

    IEnumerator StartAudio(int seconds)
    {
        while (screenClicked)
        {
            Utilities.PlayAudio(audio);
            yield return new WaitForSeconds(seconds);
        }
    }
}
