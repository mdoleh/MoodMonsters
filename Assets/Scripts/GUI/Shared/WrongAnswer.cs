using UnityEngine;
using System.Collections;

public class WrongAnswer : ButtonDragDrop
{
    private AudioSource response;

    protected override void Awake()
    {
        base.Awake();
        response = transform.parent.Find("WrongAnswerAudio").GetComponent<AudioSource>();
    }

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Wrong answer clicked");
    }

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        Debug.Log("Wrong answer submitted");
        Utilities.PlayAudio(response);
    }
}
