using UnityEngine;
using System.Collections;

public class Angry : ButtonDragDrop {

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Angry clicked");
    }

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        Debug.Log("Angry submitted");
        NextGUI();
    }
}
