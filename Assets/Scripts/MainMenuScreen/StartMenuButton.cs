using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenuButton : ButtonDoubleClick
{
    protected override void Update()
    {
        // do nothing
    }

    public override void ButtonClicked()
    {
        DisableAllGlows();
        base.ButtonClicked();
    }

    private void DisableAllGlows()
    {
        var guiElements = GameObject.FindGameObjectsWithTag("GUI");
        foreach (var guiElement in guiElements)
        {
            if (guiElement.name == "BackgroundGlow") guiElement.GetComponent<Image>().enabled = false;
            else guiElement.GetComponent<Image>().color = originalColor;
        }
    }
}
