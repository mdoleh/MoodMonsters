using UnityEngine;
using System.Collections;

public class Hot : ButtonDragDrop {

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Hot clicked");
    }

    public override void SubmitAnswer()
    {
        Debug.Log("Hot submitted");
        GameObject.Destroy(gameObject);
        correctCount += 1;
        base.SubmitAnswer();
    }
}
