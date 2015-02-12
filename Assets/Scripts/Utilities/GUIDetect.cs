using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Globals;

public class GUIDetect : MonoBehaviour {
    private static readonly IList<string> CanvasList = new List<string>
    {
        "TutorialCanvas", "EmotionsCanvas", "PhysicalCanvas1", "PhysicalCanvas2", "PhysicalCanvas3", "ActionsCanvas"
    };

    public static string GetCurrentGUIName()
    {
        var GUI = GameObject.FindGameObjectsWithTag("GUI");
        return (from t in GUI where t.GetComponent<Canvas>().enabled select t.name).FirstOrDefault();
    }

    public static Canvas GetCurrentGUI()
    {
        var GUI = GameObject.FindGameObjectsWithTag("GUI");
        return (from t in GUI where t.GetComponent<Canvas>().enabled select t.GetComponent<Canvas>()).FirstOrDefault();
    }

    public static string GetNextGUIName(string currentGUI)
    {
        var currentIndex = CanvasList.IndexOf(currentGUI);
        return currentIndex + 1 >= CanvasList.Count ? null : CanvasList[currentIndex + 1];
    }

    public static Canvas GetNextGUI(string currentGUI)
    {
        var nextGUI = GetNextGUIName(currentGUI);
        return GetGUIByName(nextGUI);
    }

    public static GameObject[] GetAllGUI()
    {
        return GameObject.FindGameObjectsWithTag("GUI");
    }

    public static Canvas GetGUIByName(string name)
    {
        var GUI = GameObject.FindGameObjectsWithTag("GUI");
        return (from t in GUI where t.name == name select t.GetComponent<Canvas>()).FirstOrDefault();
    }

    public static void NextGUI(string current, string next)
    {
        var GUI = GetAllGUI();
        foreach (var guiCanvas in GUI)
        {
            if (guiCanvas.name == next)
            {
                guiCanvas.GetComponent<Canvas>().enabled = true;
                Utilities.PlayAudio(guiCanvas.GetComponent<AudioSource>());
                Timeout.StartTimers();
                Timeout.SetRepeatAudio(guiCanvas.GetComponent<AudioSource>());
            }
            if (guiCanvas.name == current)
            {
                guiCanvas.GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
