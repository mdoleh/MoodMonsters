using System.Collections;
using UnityEngine;

public class FearfulMovementActionsMenu : FearfulMovement
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(ShowActionsMenu());
        waitingForScarlet = false;
    }

    private IEnumerator ShowActionsMenu()
    {
        yield return new WaitForSeconds(2f);
        var previousCanvas = GUIHelper.GetPreviousGUI("ActionsCanvas");
        previousCanvas.GetComponent<Canvas>().enabled = true;
        GUIHelper.NextGUI();
    }
}