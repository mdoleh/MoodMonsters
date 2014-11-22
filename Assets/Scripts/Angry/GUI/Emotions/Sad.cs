using UnityEngine;
using System.Collections;

public class Sad : ButtonDragDrop {

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Sad clicked");
    }
}
