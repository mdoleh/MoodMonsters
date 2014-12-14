using UnityEngine;
using System.Collections;

public class Fists : ButtonDragDrop
{

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Fists clicked");
    }

    public override void SubmitAnswer()
    {
        Debug.Log("Fists submitted");
        GameObject.Destroy(gameObject);
        correctCount += 1;
        base.SubmitAnswer();
    }
}
