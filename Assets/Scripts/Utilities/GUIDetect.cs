﻿using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

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
        foreach (var guiCanvas in GUI)
        {
            if (guiCanvas.name == next)
            {
                guiCanvas.GetComponent<Canvas>().enabled = true;
                if (current != "TutorialCanvas")
                {
                    Utilities.PlayAudio(guiCanvas.GetComponent<AudioSource>());
                }
                Timeout.StartTimers();
            }
            if (guiCanvas.name == current)
            {
                guiCanvas.GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
