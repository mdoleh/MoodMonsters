using UnityEngine;
using System.Collections;

public class GUIDetect : MonoBehaviour {

    public static string GetCurrentGUIName()
    {
        var GUI = GameObject.FindGameObjectsWithTag("GUI");
        for (int ii = 0; ii < GUI.Length; ++ii)
        {
            if (GUI[ii].GetComponent<Canvas>().enabled) return GUI[ii].name;
        }
        return null;
    }

    public static Canvas GetCurrentGUI()
    {
        var GUI = GameObject.FindGameObjectsWithTag("GUI");
        for (int ii = 0; ii < GUI.Length; ++ii)
        {
            if (GUI[ii].GetComponent<Canvas>().enabled) return GUI[ii].GetComponent<Canvas>();
        }
        return null;
    }

    public static GameObject[] GetAllGUI()
    {
        return GameObject.FindGameObjectsWithTag("GUI");
    }
}
