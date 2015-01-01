using UnityEngine;
using System.Collections;

public class QuitButton : ButtonSelect {

	protected override void DoubleClickAction()
    {
        Debug.Log("Quit clicked.");
    }
}
