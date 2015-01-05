using UnityEngine;
using System.Collections;
using System.Linq;

public class GUIDetect : MonoBehaviour {

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
        switch (currentGUI)
        {
            case "TutorialCanvas":
                return "EmotionsCanvas";
                break;
            case "EmotionsCanvas":
                return "PhysicalCanvas";
                break;
            case "PhysicalCanvas":
                return "ActionsCanvas";
                break;
            case "ActionsCanvas":
                // do nothing
                break;
            default:
                // do nothing
                break;
        }
        return null;
    }

    public static Canvas GetNextGUI(string currentGUI)
    {
        switch (currentGUI)
        {
            case "TutorialCanvas":
                return GetGUIByName("EmotionsCanvas");
                break;
            case "EmotionsCanvas":
                return GetGUIByName("PhysicalCanvas");
                break;
            case "PhysicalCanvas":
                return GetGUIByName("ActionsCanvas");
                break;
            case "ActionsCanvas":
                // do nothing
                break;
            default:
                // do nothing
                break;
        }
        return null;
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
        for (int ii = 0; ii < GUI.Length; ++ii)
        {
            if (GUI[ii].name == next)
            {
                GUI[ii].GetComponent<Canvas>().enabled = true;
                Utilities.PlayAudio(GUI[ii].GetComponent<AudioSource>());
            }
            if (GUI[ii].name == current)
            {
                GUI[ii].GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
