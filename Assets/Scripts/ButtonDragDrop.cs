using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// this is the base class for all dragable buttons on the GUI
// override ButtonDown() to customize click event
public class ButtonDragDrop : MonoBehaviour {

    protected Vector2 originalPosition;
    public Button dropContainer;
    Color oldColor;

    public void MoveButton() {
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // check if in range of container and highlight the container
        if (RectsOverlap(dropContainer.GetComponent<RectTransform>().rect, GetComponent<RectTransform>().rect))
        {
            oldColor = dropContainer.image.color;
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
        
        transform.position = originalPosition;
    }

    public virtual void SubmitAnswer() { }

    bool RectsOverlap(Rect r1, Rect r2) {
        bool widthOverlap =  ((r1.xMin >= r2.xMin) && (r1.xMin <= r2.xMax)) ||
                            ((r2.xMin >= r1.xMin) && (r2.xMin <= r1.xMax));
   
        bool heightOverlap = ((r1.yMin >= r2.yMin) && (r1.yMin <= r2.yMax)) ||
                            ((r2.yMin >= r1.yMin) && (r2.yMin <= r1.yMax));
                       
        return (widthOverlap && heightOverlap);
    }
}
