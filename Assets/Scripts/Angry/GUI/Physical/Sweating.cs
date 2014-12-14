using UnityEngine;
using System.Collections;

public class Sweating : ButtonDragDrop
{

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Sweating clicked");
    }

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        Debug.Log("Sweating submitted");
    }
}
