using UnityEngine;
using System.Collections;

public class ThroatClosing : ButtonDragDrop
{

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("ThroatClosing clicked");
    }

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        Debug.Log("ThroatClosing submitted");
    }
}
