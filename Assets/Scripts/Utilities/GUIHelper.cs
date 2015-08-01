using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Globals;

public class GUIHelper : MonoBehaviour {
    public static IList<string> CanvasList = new List<string>
    {
        "TutorialCanvas", "EmotionsCanvas", "PhysicalCanvas1", "PhysicalCanvas2", "PhysicalCanvas3", "ActionsCanvas"
    };

    public static IList<string> AudioIgnoreList = new List<string>();
    public static IList<string> HelpCanvasIgnoreList = new List<string>();

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

    public static string GetPreviousGUIName(string currentGUI)
    {
        var currentIndex = CanvasList.IndexOf(currentGUI);
        return currentIndex - 1 < 0 ? null : CanvasList[currentIndex - 1];
    }

    public static Canvas GetPreviousGUI(string currentGUI)
    {
        var previousGUI = GetPreviousGUIName(currentGUI);
        return GetGUIByName(previousGUI);
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

    public static void NextGUI()
    {
        var currentGUI = GetCurrentGUIName();
        NextGUI(currentGUI, GetNextGUIName(currentGUI));
    }

    private static void NextGUI(string current, string next)
    {
        var GUI = GetAllGUI();
        foreach (var guiCanvas in GUI)
        {
            if (guiCanvas.name == next)
            {
                if (!HelpCanvasIgnoreList.Contains(guiCanvas.name))
                    GameObject.Find("HelpCanvas").GetComponent<Canvas>().enabled = true;
                guiCanvas.GetComponent<Canvas>().enabled = true;
                if (!AudioIgnoreList.Contains(guiCanvas.name)) 
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
