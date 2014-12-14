using UnityEngine;
using System.Collections;

public class HeartRacing : ButtonDragDrop
{

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("HeartRacing clicked");
    }

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        Debug.Log("HeartRacing submitted");
    }
}
