using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{
    public static AudioSource CurrentPlayingSound;

    public static void ResetValues()
    {
        CurrentPlayingSound = null;
    }
}
