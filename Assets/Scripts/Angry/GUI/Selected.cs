using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selected : MonoBehaviour {

    bool selected = false;
    Color oldColor;

    public void ButtonSelected(Button button) {
        if (selected)
        {
            selected = false;
            ToggleSelection(selected, button);
        }
        else
        {
            selected = true;
            ToggleSelection(selected, button);
        }
    }

    void ToggleSelection(bool isSelected, Button button)
    {
        if (isSelected)
        {
            oldColor = button.image.color;
            button.image.color = Color.green;
        }
        else {
            button.image.color = oldColor;
        }
    }
}
