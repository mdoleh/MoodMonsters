using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Globals;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    public static void NextGUI(string current, string next)
    {
        Timeout.StopTimers();
        var GUI = GetAllGUI();
        foreach (var guiCanvas in GUI)
        {
            if (guiCanvas.name == next)
            {
                showHelpUI(guiCanvas);
                guiCanvas.GetComponent<Canvas>().enabled = true;
                Timeout.Instance.StartCoroutine(playCanvasAudio(guiCanvas));
            }
            if (guiCanvas.name == current)
            {
                guiCanvas.GetComponent<Canvas>().enabled = false;
            }
        }
    }

    private static void showHelpUI(GameObject guiCanvas)
    {
        if (!HelpCanvasIgnoreList.Contains(guiCanvas.name))
        {
            var helpCanvas = GameObject.Find("HelpCanvas");
            helpCanvas.GetComponent<Canvas>().enabled = true;
            helpCanvas.transform.FindChild("DisablePanel").gameObject.SetActive(true);
        }
    }

    private static void enableUI()
    {
        var helpCanvas = GameObject.Find("HelpCanvas");
        helpCanvas.transform.FindChild("DisablePanel").gameObject.SetActive(false);
    }

    private static IEnumerator playCanvasAudio(GameObject guiCanvas)
    {
        if (!AudioIgnoreList.Contains(guiCanvas.name))
        {
            var passReminder = guiCanvas.transform.FindChild("PASSReminder");
            if (passReminder != null && GameFlags.AdultIsPresent && GameFlags.HasSeenPASS)
            {
                var passLetters = passReminder.GetComponentsInChildren<Transform>().ToList();
                passLetters.Remove(passLetters.First(x => x.name.Equals(passReminder.name)));
                var passCanvas = GameObject.Find("PASSCanvas").transform;
                passLetters.ForEach(x => passCanvas.FindChild(x.name).gameObject.SetActive(true));
                Utilities.PlayAudio(passReminder.GetComponent<AudioSource>());
                Timeout.SetRepeatAudio(passReminder.GetComponent<AudioSource>());
                yield return new WaitForSeconds(passReminder.GetComponent<AudioSource>().clip.length);
            }
            else
            {
                Utilities.PlayAudio(guiCanvas.GetComponent<AudioSource>());
                Timeout.SetRepeatAudio(guiCanvas.GetComponent<AudioSource>());
                yield return new WaitForSeconds(guiCanvas.GetComponent<AudioSource>().clip.length);
            }

            toggleTiles(guiCanvas.transform.GetComponentsInChildren<ButtonDragDrop>().ToList(), false);
            foreach (var child in guiCanvas.transform.GetComponentsInChildren<ButtonDragDrop>())
            {
                yield return Timeout.Instance.StartCoroutine(playTileAudio(child.transform));
            }
            toggleTiles(guiCanvas.transform.GetComponentsInChildren<ButtonDragDrop>().ToList(), false);
            enableUI();
            Timeout.StartTimers();
        }
    }

    private static void toggleTiles(List<ButtonDragDrop> tiles, bool enabled)
    {
        tiles.ForEach(tile => { tile.enabled = enabled;
        });
    }

    private static IEnumerator playTileAudio(Transform tile)
    {
        var tileAudio = tile.GetComponent<AudioSource>();
        if (tileAudio == null) yield break;
        tile.GetComponent<Animator>().ResetTrigger("Normal");
        tile.GetComponent<Animator>().SetTrigger("ButtonGrow");
        Utilities.PlayAudio(tileAudio);
        yield return new WaitForSeconds(tileAudio.clip.length);
        tile.GetComponent<Animator>().SetTrigger("Normal");
    }
}
