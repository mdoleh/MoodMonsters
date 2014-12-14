using UnityEngine;
using System.Collections;

public class Tingling : ButtonDragDrop {

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Tingling clicked");
    }

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        Debug.Log("Tingling submitted");
    }
}
