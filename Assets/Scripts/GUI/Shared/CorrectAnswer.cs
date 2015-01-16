using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CorrectAnswer : ButtonDragDrop
{
    private AudioSource[] correctAudio;
    private AudioSource currentAudioPlaying;
    private Text correctCountText;

    protected override void Awake()
    {
        base.Awake();
        correctAudio = transform.parent.Find("CorrectAnswerAudio").GetComponentsInChildren<AudioSource>();
        initializeCorrectCountText();
    }

    private void initializeCorrectCountText()
    {
        var parentElement = transform.parent.Find("CorrectCount");
        if (parentElement == null) return;
        var childElement = parentElement.FindChild("Text");
        if (childElement != null) correctCountText = childElement.GetComponent<Text>();
        if (correctCountText != null) correctCountText.text = CORRECT_AMOUNT.ToString();
    }

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Correct answer clicked");
    }

    public override void SubmitAnswer()
    {
        hideButton();
        base.SubmitAnswer();
        Debug.Log("Correct answer submitted");
        playRandomAudio();
        updateCorrectCountText();
    }

    private void Update()
    {
        if (shouldShowNextGUI && !currentAudioPlaying.isPlaying)
        {
            shouldShowNextGUI = false;
            NextGUI();
        }
    }

    private void playRandomAudio()
    {
        currentAudioPlaying = correctAudio[(int)Math.Round(UnityEngine.Random.Range(0.0f, 1.0f))];
        Utilities.PlayAudio(currentAudioPlaying);
    }

    private void hideButton()
    {
        gameObject.GetComponent<Image>().enabled = false;
        gameObject.GetComponentInChildren<RawImage>().enabled = false;
    }

    private void updateCorrectCountText()
    {
        if (correctCountText != null) correctCountText.text = (CORRECT_AMOUNT - correctCount).ToString();
    }
}