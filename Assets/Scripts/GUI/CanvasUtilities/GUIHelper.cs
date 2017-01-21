﻿using System.Collections;
using System.Linq;
using Globals;
using HelpGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIHelper : MonoBehaviour
{
    public static GameObject Canvases;

    public static GameObject GetCurrentGUI()
    {
        return GetAllGUI()[CanvasList.GetIndex()];
    }

    public static GameObject GetNextGUI()
    {
        return GetAllGUI()[CanvasList.GetIndex() + 1];
    }

    public static GameObject[] GetAllGUI()
    {
        return Canvases.GetComponent<CanvasList>().Canvases;
    }

    public static GameObject[] GetAudioIgnoreList()
    {
        return Canvases.GetComponent<CanvasList>().AudioIgnoreList;
    }

    public static GameObject[] GetHelpCanvasIgnoreList()
    {
        return Canvases.GetComponent<CanvasList>().HelpCanvasIgnoreList;
    }

    public static GameObject[] GetDisableCanvasIgnoreList()
    {
        return Canvases.GetComponent<CanvasList>().DisableCanvasIgnoreList;
    }

    public static GameObject GetGUIByName(string name)
    {
        return GetAllGUI().ToList().First(x => x.name.Equals(name));
    }

    // This is usually the method that gets called in most places
    // the overloaded method should only be called if for some
    // reason the "PassTablet" canvas should not show (ex: after a scene reset)
    public static void NextGUI()
    {
        var current = GetCurrentGUI();
        var next = GetNextGUI();
        if (!showPassTablet(current, next))
            NextGUI(current, next);
    }

    // Hides the current canvas and shows the next canvas in the flow
    public static void NextGUI(GameObject current, GameObject next)
    {
        Timeout.StopTimers();
        if (!GetHelpCanvasIgnoreList().Contains(next))
        {
            HelpCanvas.EnableHelpCanvas(true);
            HelpCanvas.Interactive(false);
            HelpCanvas.EnableHintButton(true);
        }
        if (current != null)
        {
            if (!GetDisableCanvasIgnoreList().Contains(current)) current.SetActive(false);
            else current.GetComponent<Canvas>().enabled = false;
            CanvasList.IncrementIndex();
            var hintToNotify = current.GetComponent<HintBase>();
            if (hintToNotify != null) hintToNotify.NotifyCanvasChange();
        }
        next.SetActive(true);
        var emotionHint = next.GetComponent<EmotionHint>();
        if (emotionHint != null) emotionHint.ShowHint(false);
        Timeout.Instance.StartCoroutine(playCanvasAudio(next));
    }

    // Determines if the "PassTablet" canvas should show based on the canvas names
    // "PassTablet" shows when moving from a Parent-specific question to a child-specific question
    // or vice versa
    private static bool showPassTablet(GameObject current, GameObject next)
    {
        // if we're not in an emotion scene or an adult is not present 
        // then we don't need to worry about showing the "PassTablet" canvas
        // (ex: pre-scene questions)
        if (!GameFlags.AdultIsPresent || !SceneManager.GetActiveScene().name.Contains("SmallCity")) return false;
        if (!PassTablet.HasInstance()) return false;
        if (current.name.ToLower().Contains("parent") && !next.name.ToLower().Contains("parent"))
        {
            current.SetActive(false);
            PassTablet.SwitchToChild();
            return true;
        }
        if (!current.name.ToLower().Contains("parent") && next.name.ToLower().Contains("parent"))
        {
            current.SetActive(false);
            PassTablet.SwitchToParent();
            return true;
        }
        return false;
    }

    // These are audio hints that play the first time through that
    // help the player understand what the correct answers are
    private static IEnumerator playGuidedTutorial(GameObject guiCanvas)
    {
        if (GameFlags.GuidedTutorialHasRun) yield break;
        var guidedTutorial = GameObject.Find("GuidedTutorial");
        if (guidedTutorial == null) yield break;
        var guidedAudio = guidedTutorial.GetComponentsInChildren<AudioSource>();
        var currentAudio =
            guidedAudio.ToList()
                .FindAll(x => guiCanvas.name.ToLower().Equals(x.gameObject.name.ToLower() + "canvas") &&
                    !x.gameObject.name.ToLower().Contains("parent"));
        if (currentAudio.Count < 1) yield break;
        // physical questions are asked 3 times, we only want the 
        // tutorial audio to play once for the question type
        if (guiCanvas.name.ToLower().Contains("physical") && !guiCanvas.name.Contains("1")) yield break;
        Utilities.PlayAudio(currentAudio.First());
        yield return new WaitForSeconds(currentAudio.First().clip.length);
    }

    private static IEnumerator playCanvasAudio(GameObject guiCanvas)
    {
        if (GetAudioIgnoreList().Contains(guiCanvas)) yield break;
        
        // shows the PASS letters to the player and plays the "PASSReminder" audio clip
        // which contains the question along with an additional audio snippet
        var passReminder = guiCanvas.transform.FindChild("PASSReminder");
        if (passReminder != null && GameFlags.AdultIsPresent && GameFlags.HasSeenPASS)
        {
            var passLetters = passReminder.GetComponentsInChildren<Transform>().ToList();
            // removes PASSReminder parent object from the list of letters
            passLetters.Remove(passLetters.First(x => x.name.Equals(passReminder.name)));
            var passCanvas = GameObject.Find("PASSCanvas").transform;
            passLetters.ForEach(x => passCanvas.FindChild(x.name).gameObject.SetActive(true));
            Utilities.PlayAudio(passReminder.GetComponent<AudioSource>());
            Timeout.SetRepeatAudio(passReminder.GetComponent<AudioSource>());
            yield return new WaitForSeconds(passReminder.GetComponent<AudioSource>().clip.length);
        }
        // plays the question audio for the player
        else
        {
            var guiAudio = guiCanvas.GetComponent<AudioSource>();
            if (guiAudio == null)
                guiAudio = guiCanvas.transform.Find("Questions")
                .GetComponentsInChildren<AudioSource>()
                .ToList()
                .Find(x => x.gameObject.name.ToLower().Equals(GameFlags.PlayerGender.ToLower()));
            Utilities.PlayAudio(guiAudio);
            Timeout.SetRepeatAudio(guiAudio);
            yield return new WaitForSeconds(guiAudio.clip.length);
        }

        // reads off the answer choices to the player one at a time
        var tiles = guiCanvas.transform.GetComponentsInChildren<ButtonDragDrop>().ToList();
        foreach (var child in tiles)
        {
            yield return Timeout.Instance.StartCoroutine(playTileAudio(child.transform));
        }
        yield return Timeout.Instance.StartCoroutine(playGuidedTutorial(guiCanvas));
        HelpCanvas.Interactive(true);
        Timeout.StartTimers();
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
