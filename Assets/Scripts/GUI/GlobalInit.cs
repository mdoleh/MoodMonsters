using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Globals;

// Clears out the game state and prevents the screen from sleeping
public class GlobalInit : MonoBehaviour
{
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Timeout.ResetValues();
        GameFlags.ResetValues();
        Scenes.ResetValues();
        Help.ResetValues();
        Sound.ResetValues();
        CanvasList.ResetIndex();
    }
}
