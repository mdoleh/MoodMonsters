using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Globals;
using ScaredScene;

public class FearfulMovementActionsMenu : FearfulMovement
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(ShowActionsMenu());
        waitingForScarlet = false;
        joystickInstructionsAlreadyPlayed = true;
    }

    private IEnumerator ShowActionsMenu()
    {
        yield return new WaitForSeconds(2f);
        var actionsCanvas = GameObject.Find("ActionsCanvas");
        actionsCanvas.GetComponent<Canvas>().enabled = true;
        Utilities.PlayAudio(actionsCanvas.GetComponent<AudioSource>());
        EnableHelpUI();
    }
}