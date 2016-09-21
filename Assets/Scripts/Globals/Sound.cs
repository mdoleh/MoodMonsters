using UnityEngine;
using System.Collections;

// Used primarily by the Utilities class to stop the current
// audio clip playing before starting another one
public static class Sound
{
    public static AudioSource CurrentPlayingSound;

    public static void ResetValues()
    {
        CurrentPlayingSound = null;
    }
}
