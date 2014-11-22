using UnityEngine;
using System.Collections;

// this is the base class for all dragable buttons on the GUI
// override ButtonDown() to customize click event
public class ButtonDragDrop : MonoBehaviour {

    protected Vector2 originalPosition;

    public void MoveButton() {
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    public virtual void ButtonDown()
    {
        originalPosition = transform.position; 
    }

    public virtual void ButtonRelease()
    {
        transform.position = originalPosition;
    }
}
