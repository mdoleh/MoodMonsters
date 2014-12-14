using UnityEngine;
using System.Collections;

public class Butterflies : ButtonDragDrop {

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Butterflies clicked");
    }

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        Debug.Log("Butterflies submitted");
    }
}
