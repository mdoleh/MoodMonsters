using Globals;
using UnityEngine;
using UnityEngine.UI;

public class RunTutorial : MonoBehaviour
{
    private AudioSource sceneAudio;
    private AudioSource buttonPushAudio;
    private AudioSource helpAudio;
    private AudioSource quitAudio;
    private AudioSource repeatAudio;

    private GameObject practiceDropContainer;
    private GameObject practiceButton;
    private GameObject buttonPush;
    private GameObject initCanvas;
    private GameObject helpCanvas;
    private Color originalColor;

    private bool initialAudioPlayed = false;
    private bool explainingHelpButton = false;
    private bool explainingQuitButton = false;
    private bool explainingRepeatButton = false;

    public void Initialize()
    {
        sceneAudio = GUIDetect.GetNextGUI(GUIDetect.GetCurrentGUIName()).GetComponent<AudioSource>();
        Utilities.PlayAudio(sceneAudio);
        initialAudioPlayed = true;

        InitializeGameObjects();
        InitializeAudio();
    }

    private void Update()
    {
        if (initialAudioPlayed && !sceneAudio.isPlaying) EnablePracticeUI();
        if (explainingHelpButton && !helpAudio.isPlaying)
        {
            explainingHelpButton = false;
            ResetHighlight(helpCanvas.transform.Find("Help"));
            ExplainButton(helpCanvas, "Quit", ref explainingQuitButton, ref quitAudio);
        }
        if (explainingQuitButton && !quitAudio.isPlaying)
        {
            explainingQuitButton = false;
            ResetHighlight(helpCanvas.transform.Find("Quit"));
            ExplainButton(helpCanvas, "Repeat", ref explainingRepeatButton, ref repeatAudio);
        }
        if (explainingRepeatButton && !repeatAudio.isPlaying)
        {
            explainingRepeatButton = false;
            ResetHighlight(helpCanvas.transform.Find("Repeat"));
            var currentGUI = GUIDetect.GetCurrentGUIName();
            GUIDetect.NextGUI(currentGUI, GUIDetect.GetNextGUIName(currentGUI));
        }
    }

    private void InitializeGameObjects()
    {
        practiceDropContainer = transform.Find("DropContainer").gameObject;
        practiceButton = transform.Find("PracticeButton").gameObject;
        buttonPush = transform.Find("ButtonPush").gameObject;
        initCanvas = GameObject.Find("InitCanvas");
        helpCanvas = GameObject.Find("HelpCanvas");
    }

    private void InitializeAudio()
    {
        buttonPushAudio = transform.Find("ButtonPush").gameObject.GetComponent<AudioSource>();
    }

    private void EnablePracticeUI()
    {
        initialAudioPlayed = false;
        practiceDropContainer.SetActive(true);
        practiceButton.SetActive(true);
        buttonPush.SetActive(true);
        initCanvas.SetActive(false);
        Utilities.PlayAudio(buttonPushAudio);
        Timeout.StartTimers();
        Timeout.SetRepeatAudio(buttonPushAudio);
    }

    public void ExplainHelpUI()
    {
        Sound.CurrentPlayingSound = sceneAudio;
        ExplainButton(helpCanvas, "Help", ref explainingHelpButton, ref helpAudio);
    }

    private void ExplainButton(GameObject helpCanvas, string name, ref bool explaining, ref AudioSource audio)
    {
        var buttonParent = helpCanvas.transform.Find(name).gameObject;
        audio = buttonParent.GetComponent<AudioSource>();
        Utilities.PlayAudio(audio);

        originalColor = buttonParent.transform.Find(buttonParent.name + "Button").GetComponent<Image>().color;
        buttonParent.transform.Find(buttonParent.name + "Button").GetComponent<Image>().color = Color.yellow;
        buttonParent.transform.Find("BackgroundGlow").GetComponent<Image>().enabled = true;

        explaining = true;
    }

    private void ResetHighlight(Transform button)
    {
        button.Find(button.gameObject.name + "Button").GetComponent<Image>().color = originalColor;
        button.Find("BackgroundGlow").GetComponent<Image>().enabled = false;
    }
}
