using UnityEngine;
using System.Collections;
using Globals;

// Allows you to define a "Default" action that can be triggered by Default Canvases
public class DefaultActionBase : CorrectActionBase
{
    public void StartDefaultAction()
    {
        Timeout.StopTimers();
        StartCoroutine(Explain());
    }

    private IEnumerator Explain()
    {
        yield return new WaitForSeconds(0.5f);
        DialogueAnimation();
        Utilities.PlayAudio(dialogue);
        yield return new WaitForSeconds(dialogue.clip.length);
        AfterDialogue();
    }
}