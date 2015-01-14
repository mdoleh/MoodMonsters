﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// this is the base class for all dragable buttons on the GUI
// override ButtonDown() to customize click event
public class ButtonDragDrop : MonoBehaviour {

    private static int correctCount = 0;
    protected Vector2 originalPosition;
    protected AudioSource buttonAudio;
    public Button dropContainer;
    private Color oldColor;
    public int CORRECT_AMOUNT = 3;
    protected bool shouldShowNextGUI = false;

    protected virtual void Awake() {
        oldColor = dropContainer.image.color;
        buttonAudio = GetComponent<AudioSource>();
    }

    public void MoveButton() {
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // check if in range of container and highlight the container
        if (RectsOverlap(dropContainer.GetComponent<RectTransform>(), GetComponent<RectTransform>()))
        {
            dropContainer.image.color = Color.red;
        }
        else
        {
            dropContainer.image.color = oldColor;
        }
    }

    public virtual void ButtonDown()
    {
        originalPosition = transform.position;
        Utilities.PlayAudio(buttonAudio);
    }

    public virtual void ButtonRelease()
    {
        if (RectsOverlap(dropContainer.GetComponent<RectTransform>(), GetComponent<RectTransform>()))
        {
            dropContainer.image.color = oldColor;
            SubmitAnswer();
        }
        transform.position = originalPosition;
    }

    public virtual void SubmitAnswer() {
        correctCount += 1;
        if (correctCount == CORRECT_AMOUNT)
        {
            shouldShowNextGUI = true;
            //NextGUI();
        }
    }

    protected void DecrementCorrectCount()
    {
        --correctCount;
    }

    bool RectsOverlap(RectTransform r1, RectTransform r2)
    {
        bool widthOverlap = (r1.position.x >= r2.position.x && r1.position.x <= r2.position.x + r2.rect.width * 0.4) ||
                            (r2.position.x >= r1.position.x && r2.position.x <= r1.position.x + r1.rect.width * 0.4);

        bool heightOverlap = (r1.position.y >= r2.position.y && r1.position.y <= r2.position.y + r2.rect.height * 0.4) ||
                            (r2.position.y >= r1.position.y && r2.position.y <= r1.position.y + r1.rect.height * 0.4);
                       
        return (widthOverlap && heightOverlap);
    }

    protected void HideGUI()
    {
        GUIDetect.GetCurrentGUI().enabled = false;
    }

    protected void NextGUI()
    {
        correctCount = 0;
        string currentGUI = GUIDetect.GetCurrentGUIName();
        switch (currentGUI)
        {
            case "TutorialCanvas":
                GUIDetect.NextGUI("TutorialCanvas", "EmotionsCanvas");
                break;
            case "EmotionsCanvas":
                GUIDetect.NextGUI("EmotionsCanvas", "PhysicalCanvas");
                break;
            case "PhysicalCanvas":
                GUIDetect.NextGUI("PhysicalCanvas", "ActionsCanvas");
                break;
            case "ActionsCanvas":
                // go to puzzle mini game
                break;
            default:
                // do nothing
                break;
        }
        
    }
}
