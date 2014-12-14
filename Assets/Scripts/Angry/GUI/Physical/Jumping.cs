using UnityEngine;
using System.Collections;

public class Jumping : ButtonDragDrop
{

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Jumping clicked");
    }

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        Debug.Log("Jumping submitted");
    }
}
