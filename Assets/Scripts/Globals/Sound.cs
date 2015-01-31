using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{
    public static AudioSource CurrentPlayingSound;
    public static AudioSource PreviousSound;

    public static void ResetValues()
    {
        CurrentPlayingSound = null;
        PreviousSound = null;
    }

    public static void RestorePreviousSound()
    {
        if (PreviousSound == null) return;
        CurrentPlayingSound = PreviousSound;
        PreviousSound = null;
    }
}
