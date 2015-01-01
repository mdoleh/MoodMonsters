using UnityEngine;
using System.Collections;

public class HelpButton : ButtonSelect {

	protected override void DoubleClickAction()
    {
        Debug.Log("Help clicked.");
    }
}
