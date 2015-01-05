using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PracticeButton : ButtonDragDrop {
    private AudioSource buttonDragAudio;
    private AudioSource buttonPushAudio;
    private AudioSource practiceButtonAudio;
    private AudioSource helpAudio;
    private AudioSource quitAudio;
    private AudioSource repeatAudio;

    private bool shouldPlayDragAudio = false;
    private bool answerSubmitted = false;
    private bool explainingHelpButton = false;
    private bool explainingQuitButton = false;
    private bool explainingRepeatButton = false;

    private GameObject helpCanvas;
    private Color originalColor;

    protected override void Awake()
    {
        base.Awake();
        CORRECT_AMOUNT = 1;

        buttonPushAudio = transform.parent.Find("ButtonPush").gameObject.GetComponent<AudioSource>();
        buttonDragAudio = transform.parent.Find("ButtonDrag").gameObject.GetComponent<AudioSource>();
        practiceButtonAudio = transform.parent.Find("PracticeButton").gameObject.GetComponent<AudioSource>();
        helpCanvas = GameObject.Find("HelpCanvas");
    }

    public override void ButtonDown()
    {
        base.ButtonDown();
        ShowDragging();
    }

    public override void ButtonRelease()
    {
        base.ButtonRelease();
        //ShowPushing();
    }

    public override void SubmitAnswer()
    {
        answerSubmitted = true;
        HidePracticeUI();
        ExplainButton(helpCanvas, "Help", ref explainingHelpButton, ref helpAudio);
    }

    private void Update()
    {
        if (shouldPlayDragAudio && !practiceButtonAudio.isPlaying)
        {
            Utilities.PlayAudio(buttonDragAudio);
            shouldPlayDragAudio = false;
        }
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
            NextGUI();
        }
    }

    private void ShowDragging()
    {
        Utilities.StopAudio(buttonPushAudio);
        transform.parent.Find("ButtonPush").gameObject.SetActive(false);
        transform.parent.Find("ButtonDrag").gameObject.SetActive(true);
        shouldPlayDragAudio = true;
    }

    private void HidePracticeUI()
    {
        transform.parent.Find("ButtonPush").gameObject.SetActive(false);
        transform.parent.Find("ButtonDrag").gameObject.SetActive(false);
        transform.parent.Find("DropContainer").gameObject.SetActive(false);
//        transform.parent.Find("PracticeButton").gameObject.SetActive(false);
    }

    private void ShowPushing()
    {
        if (!answerSubmitted)
        {
            Utilities.StopAudio(buttonDragAudio);
            transform.parent.Find("ButtonPush").gameObject.SetActive(true);
            transform.parent.Find("ButtonDrag").gameObject.SetActive(false);
            Utilities.PlayAudio(buttonPushAudio);
        }
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
