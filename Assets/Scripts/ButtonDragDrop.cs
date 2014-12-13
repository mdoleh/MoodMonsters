using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// this is the base class for all dragable buttons on the GUI
// override ButtonDown() to customize click event
public class ButtonDragDrop : MonoBehaviour {

    protected Vector2 originalPosition;
    public Button dropContainer;
    Color oldColor;

    public virtual void Awake() {
        oldColor = dropContainer.image.color;
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
    }

    public virtual void ButtonRelease()
    {
        if (RectsOverlap(dropContainer.GetComponent<RectTransform>(), GetComponent<RectTransform>()))
        {
            SubmitAnswer();
        }
        transform.position = originalPosition;
    }

    public virtual void SubmitAnswer() { }

    bool RectsOverlap(RectTransform r1, RectTransform r2)
    {
        bool widthOverlap = (r1.position.x >= r2.position.x && r1.position.x <= r2.position.x + r2.rect.width * 0.4) ||
                            (r2.position.x >= r1.position.x && r2.position.x <= r1.position.x + r1.rect.width * 0.4);

        bool heightOverlap = (r1.position.y >= r2.position.y && r1.position.y <= r2.position.y + r2.rect.height * 0.4) ||
                            (r2.position.y >= r1.position.y && r2.position.y <= r1.position.y + r1.rect.height * 0.4);
                       
        return (widthOverlap && heightOverlap);
    }
}
