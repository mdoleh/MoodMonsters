using UnityEngine;
using System.Collections;
using Globals;

public class DefaultActionBase : CorrectActionBase
{
    public void StartDefaultAction()
    {
        Timeout.StopTimers();
        StartCoroutine(Explain());
    }

    private IEnumerator Explain()
    {
        DialogueAnimation();
        Utilities.PlayAudio(dialogue);
        yield return new WaitForSeconds(dialogue.clip.length);
        AfterDialogue();
    }
}