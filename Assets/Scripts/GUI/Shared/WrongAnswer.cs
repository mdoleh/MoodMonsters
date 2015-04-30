using UnityEngine;
using System.Collections;

public class WrongAnswer : ButtonDragDrop
{
    private AudioSource[] wrongAudio;

    protected override void Awake()
    {
        base.Awake();
        wrongAudio = transform.parent.Find("WrongAnswerAudio").GetComponentsInChildren<AudioSource>();
    }

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Wrong answer clicked");
    }

    public override void SubmitAnswer()
    {
        DecrementCorrectCount();
        base.SubmitAnswer();
        Debug.Log("Wrong answer submitted");
        Utilities.PlayRandomAudio(wrongAudio);
    }
}
