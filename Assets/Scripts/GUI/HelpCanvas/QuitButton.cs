using UnityEngine;
using System.Collections;

public class QuitButton : ButtonSelect {

	protected override void DoubleClickAction()
    {
        Utilities.LoadScene("TitleScreen");
    }
}
