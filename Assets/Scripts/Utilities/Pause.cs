using UnityEngine;
using System.Collections;
using Globals;

public class Pause : MonoBehaviour
{
    private float originalScale;
    private bool paused = false;

    private void Start()
    {
        originalScale = Time.timeScale;
    }

    public void OnClick()
    {
        if (paused) unPauseGame();
        else pauseGame();
    }

    private void pauseGame()
    {
        Time.timeScale = 0;
        paused = true;
        Timeout.StopTimers();
        Utilities.PauseAudio(Sound.CurrentPlayingSound);
    }

    private void unPauseGame()
    {
        Time.timeScale = originalScale;
        paused = false;
        Timeout.StartTimers();
        Utilities.UnPauseAudio(Sound.CurrentPlayingSound);
    }
}
