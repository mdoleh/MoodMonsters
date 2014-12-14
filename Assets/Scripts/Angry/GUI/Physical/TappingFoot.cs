using UnityEngine;
using System.Collections;

public class TappingFoot : ButtonDragDrop
{

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("TappingFoot clicked");
    }

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        Debug.Log("TappingFoot submitted");
    }
}
