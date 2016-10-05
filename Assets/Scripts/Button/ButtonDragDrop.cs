using UnityEngine;
using System.Collections;
using Globals;
using UnityEngine.UI;

// this is the base class for all draggable buttons on the GUI
public class ButtonDragDrop : MonoBehaviour {

    protected static int correctCount = 0;
    protected Vector2 originalPosition;
    protected AudioSource buttonAudio;
    // container where answers can be submitted
    public Button dropContainer;
    private Color oldColor;
    // number of correct answers that can be submitted
    // not really used anymore, defaults to 1
    protected int CORRECT_AMOUNT;
    protected bool shouldShowNextGUI = false;
    private static Transform currentlyDraggingPiece;

    protected virtual void Awake()
    {
        correctCount = 0;
        oldColor = dropContainer.image.color;
        buttonAudio = GetComponent<AudioSource>();
        initializeCorrectAmount();
    }

    private void Update()
    {
        if (Input.touchCount > 1 && currentlyDraggingPiece == transform)
        {
            transform.position = originalPosition;
            dropContainer.image.color = oldColor;
            currentlyDraggingPiece = null;
        }
    }

    public void MoveButton() {
        if (currentlyDraggingPiece != transform) return;
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

    // what happens when a button is touched
    public virtual void ButtonDown()
    {
        if (Input.touchCount > 1) return;
        currentlyDraggingPiece = transform;
        originalPosition = transform.position;
        Utilities.PlayAudio(buttonAudio);
        Timeout.StopTimers();
        StopAllCoroutines();
    }

    // what happens when a button is released
    public virtual void ButtonRelease()
    {
        if (currentlyDraggingPiece != transform) return;
        if (RectsOverlap(dropContainer.GetComponent<RectTransform>(), GetComponent<RectTransform>()))
        {
            dropContainer.image.color = oldColor;
            SubmitAnswer();
        }
        else Timeout.StartTimers();
        transform.position = originalPosition;
    }

    // if a draggable element is dropped into the submission box
    public virtual void SubmitAnswer() {
        Timeout.StopTimers();
        StopAllCoroutines();
        correctCount += 1;
        if (correctCount == CORRECT_AMOUNT)
        {
            shouldShowNextGUI = true;
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
        GameObject.Find("HelpCanvas").GetComponent<Canvas>().enabled = false;
        GUIHelper.GetCurrentGUI().GetComponent<Canvas>().enabled = false;
    }

    // navigate to the next question
    protected void NextGUI()
    {
        correctCount = 0;
        GUIHelper.NextGUI();       
    }

    private void initializeCorrectAmount()
    {
        var correctAmount = transform.parent.Find("CorrectAmount");
        if (correctAmount != null)
        {
            CORRECT_AMOUNT = correctAmount.GetComponent<CorrectAmount>().CORRECT_AMOUNT;
        }
    }
}
