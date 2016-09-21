using UnityEngine;
using System.Collections;

// Triggers an action on a character
// Actions are assigned in the Editor
// Since all actions are of type ActionBase, before assigning,
// move the desired action to the top of the components list of the GameObject
// These are the answer choices for Actions questions
public class GUIAction : ButtonDragDrop
{
    public ActionBase action;

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        action.StartAction();
        HideGUI();
    }
}
