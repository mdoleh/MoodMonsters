using System.Collections;
using AngryScene;
using Globals;
using UnityEngine;
using UnityEngine.UI;

public class RunTutorial : MonoBehaviour
{
    private AudioSource buttonPushAudio;
    private AudioSource helpAudio;
    private AudioSource quitAudio;
    private AudioSource repeatAudio;
    private AudioSource helpLilyPlayAudio;

    public GameObject otherCharacter;
    private GameObject practiceDropContainer;
    private GameObject practiceButton;
    private GameObject buttonPush;
    private GameObject initCanvas;
    private GameObject helpCanvas;
    private GameObject disablePanel;
    private GameObject fingerDrag;
    private Color originalColor;

    private bool initialAudioPlayed = false;
    private bool explainingHelpButton = false;
    private bool explainingQuitButton = false;
    private bool explainingRepeatButton = false;

    public void Start()
    {
        StartCoroutine(DelayPlayAudio());

        InitializeGameObjects();
        InitializeAudio();
    }

    private IEnumerator DelayPlayAudio()
    {
        yield return new WaitForSeconds(1f);
        Utilities.PlayAudio(GetComponent<AudioSource>());
        initialAudioPlayed = true;
    }

    private void Update()
    {
        if (initialAudioPlayed && !GetComponent<AudioSource>().isPlaying) EnablePracticeUI();
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
            StartCoroutine(PlayHelpLilyPlayAudio());
        }
    }

    private IEnumerator PlayHelpLilyPlayAudio()
    {
        Utilities.PlayAudio(helpLilyPlayAudio);
        fingerDrag.SetActive(true);
        yield return new WaitForSeconds(helpLilyPlayAudio.clip.length);
        fingerDrag.SetActive(false);
        otherCharacter.SetActive(true);
        otherCharacter.GetComponent<WalkForward>().StartWalking();
    }

    public void EnableHelpGUI()
    {
        Tutorials.MainTutorialHasRun = true;
        disablePanel.SetActive(false);
        GetComponent<Canvas>().enabled = false;
    }

    private void InitializeGameObjects()
    {
        practiceDropContainer = transform.Find("DropContainer").gameObject;
        practiceButton = transform.Find("PracticeButton").gameObject;
        buttonPush = transform.Find("ButtonPush").gameObject;
        helpCanvas = GameObject.Find("HelpCanvas");
        disablePanel = helpCanvas.transform.FindChild("DisablePanel").gameObject;
        fingerDrag = transform.Find("FingerDrag").gameObject;
    }

    private void InitializeAudio()
    {
        buttonPushAudio = transform.Find("ButtonPush").gameObject.GetComponent<AudioSource>();
        helpLilyPlayAudio = transform.Find("HelpLilyPlay").gameObject.GetComponent<AudioSource>();
    }

    private void EnablePracticeUI()
    {
        initialAudioPlayed = false;
        practiceDropContainer.SetActive(true);
        practiceButton.SetActive(true);
        buttonPush.SetActive(true);
        Utilities.PlayAudio(buttonPushAudio);
        Timeout.StartTimers();
        Timeout.SetRepeatAudio(buttonPushAudio);
    }

    public void ExplainHelpUI()
    {
        helpCanvas.GetComponent<Canvas>().enabled = true;
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
