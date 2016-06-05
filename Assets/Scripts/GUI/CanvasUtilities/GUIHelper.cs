using System.Collections;
using System.Linq;
using Globals;
using UnityEngine;

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

    public static void NextGUI()
    {
        var current = GetCurrentGUI();
        var next = GetNextGUI();
        if (!showPassTablet(current, next))
            NextGUI(current, next);
    }

    public static void NextGUI(GameObject current, GameObject next)
    {
        Timeout.StopTimers();
        showHelpUI(next);
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

    private static bool showPassTablet(GameObject current, GameObject next)
    {
        if (!GameFlags.AdultIsPresent) return false;
        current.SetActive(false);
        var passTablet = GameObject.Find("PassTabletCanvas").GetComponent<PassTablet>();
        if (current.name.ToLower().Contains("parent") && !next.name.ToLower().Contains("parent"))
        {
            passTablet.SwitchToChild();
            return true;
        }
        if (!current.name.ToLower().Contains("parent") && next.name.ToLower().Contains("parent"))
        {
            passTablet.SwitchToParent();
            return true;
        }
        return false;
    }

    private static IEnumerator playGuidedTutorial(GameObject guiCanvas)
    {
        if (GameFlags.GuidedTutorialHasRun) yield break;
        var guidedTutorial = GameObject.Find("GuidedTutorial");
        if (guidedTutorial == null) yield break;
        var guidedAudio = guidedTutorial.GetComponentsInChildren<AudioSource>();
        var currentAudio =
            guidedAudio.ToList()
                .Find(x => guiCanvas.name.ToLower().Contains(x.gameObject.name.ToLower()) &&
                    !x.gameObject.name.ToLower().Contains("parent"));
        if (guiCanvas.name.ToLower().Contains("physical") && !guiCanvas.name.Contains("1")) yield break;
        Utilities.PlayAudio(currentAudio);
        yield return new WaitForSeconds(currentAudio.clip.length);
    }

    private static void showHelpUI(GameObject guiCanvas)
    {
        if (GetHelpCanvasIgnoreList().Contains(guiCanvas)) return;
        var helpCanvas = GameObject.Find("HelpCanvas");
        helpCanvas.GetComponent<Canvas>().enabled = true;
        helpCanvas.transform.FindChild("DisablePanel").gameObject.SetActive(true);
    }

    private static void enableUI()
    {
        var helpCanvas = GameObject.Find("HelpCanvas");
        if (helpCanvas != null)
            helpCanvas.transform.FindChild("DisablePanel").gameObject.SetActive(false);
    }

    private static IEnumerator playCanvasAudio(GameObject guiCanvas)
    {
        if (GetAudioIgnoreList().Contains(guiCanvas)) yield break;
        
        var passReminder = guiCanvas.transform.FindChild("PASSReminder");
        if (passReminder != null && GameFlags.AdultIsPresent && GameFlags.HasSeenPASS)
        {
            var passLetters = passReminder.GetComponentsInChildren<Transform>().ToList();
            // removes PASSReminder from the list of letters
            passLetters.Remove(passLetters.First(x => x.name.Equals(passReminder.name)));
            var passCanvas = GameObject.Find("PASSCanvas").transform;
            passLetters.ForEach(x => passCanvas.FindChild(x.name).gameObject.SetActive(true));
            Utilities.PlayAudio(passReminder.GetComponent<AudioSource>());
            Timeout.SetRepeatAudio(passReminder.GetComponent<AudioSource>());
            yield return new WaitForSeconds(passReminder.GetComponent<AudioSource>().clip.length);
        }
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

        var tiles = guiCanvas.transform.GetComponentsInChildren<ButtonDragDrop>().ToList();
        foreach (var child in tiles)
        {
            yield return Timeout.Instance.StartCoroutine(playTileAudio(child.transform));
        }
        yield return Timeout.Instance.StartCoroutine(playGuidedTutorial(guiCanvas));
        enableUI();
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
