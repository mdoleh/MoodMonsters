using System.Collections;
using UnityEngine;

public class CorrectAnswerWithDialogue : CorrectAnswer
{
    public AudioSource dialogue;
    public Animator speaker;

    protected override IEnumerator ShowNextGUI()
    {
        var currentAudio = Utilities.PlayRandomAudio(correctAudio);
        yield return new WaitForSeconds(currentAudio.clip.length);
        speaker.SetTrigger("Talk");
        Utilities.PlayAudio(dialogue);
        yield return new WaitForSeconds(dialogue.clip.length);
        speaker.SetTrigger("Idle");
        if (shouldShowNextGUI)
        {
            shouldShowNextGUI = false;
            NextGUI();
        }
    }
}