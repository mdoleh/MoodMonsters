using UnityEngine;
using System.Collections;
using Globals;

// Customizable action that assume the answer is incorrect
public class IncorrectActionBase : ActionBase
{
    public AudioSource dialogue;

    public override void StartAction()
    {
        base.StartAction();
        StartCoroutine(PlayDialogue());
    }

    private IEnumerator PlayDialogue()
    {
        DialogueAnimation();
        Utilities.PlayAudio(dialogue);
        if (dialogue != null)
            yield return new WaitForSeconds(dialogue.clip.length);
        AfterDialogue();
        TriggerIncorrect();
    }

    protected virtual void DialogueAnimation() {}

    protected virtual void AfterDialogue() {}
}