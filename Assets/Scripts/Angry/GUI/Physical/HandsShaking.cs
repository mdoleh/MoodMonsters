using UnityEngine;
using System.Collections;

public class HandsShaking : ButtonDragDrop
{

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("HandsShaking clicked");
    }

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        Debug.Log("HandsShaking submitted");
    }
}
