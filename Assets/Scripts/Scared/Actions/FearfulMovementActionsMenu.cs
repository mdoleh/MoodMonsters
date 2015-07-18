﻿using System.Collections;
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
        var actionsCanvas = GameObject.Find("ActionsCanvas");
        actionsCanvas.GetComponent<Canvas>().enabled = true;
        Utilities.PlayAudio(actionsCanvas.GetComponent<AudioSource>());
        EnableHelpGUI();
    }
}