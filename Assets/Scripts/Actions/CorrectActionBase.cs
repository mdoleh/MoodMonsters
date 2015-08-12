using UnityEngine;
using System.Collections;
using Globals;

public class CorrectActionBase : ActionBase
{
    public AudioSource dialogue;
    public AudioSource additionalActionExplanation;

    public override void StartAction()
    {
        base.StartAction();
        ShowCorrect(true);
        StartCoroutine(Explain());
    }

    private IEnumerator Explain()
    {
        Utilities.PlayAudio(actionExplanation);
        yield return new WaitForSeconds(actionExplanation.clip.length);
        Utilities.PlayAudio(additionalActionExplanation);
        if (additionalActionExplanation != null) yield return new WaitForSeconds(additionalActionExplanation.clip.length);
        ShowCorrect(false);
        DialogueAnimation();
        Utilities.PlayAudio(dialogue);
        yield return new WaitForSeconds(dialogue.clip.length);
        AfterDialogue();
    }

    protected virtual void DialogueAnimation() { }
    
    protected virtual void AfterDialogue() { }
}