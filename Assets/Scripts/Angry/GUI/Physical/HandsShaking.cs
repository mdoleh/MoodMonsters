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
        Debug.Log("HandsShaking submitted");
        GameObject.Destroy(gameObject);
        correctCount += 1;
        base.SubmitAnswer();
    }
}
