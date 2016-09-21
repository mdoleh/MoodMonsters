using UnityEngine;

namespace HelpGUI
{
    // Pulls the Hint off the current Canvas and triggers it
    // used by the HelpButton
    public class HelpButton : HelpBase
    {
        protected override void DoubleClickAction()
        {
            base.DoubleClickAction();
            var hint = GUIHelper.GetCurrentGUI().GetComponent<HintBase>();
            if (hint != null) hint.ShowHint();
            Debug.Log("Help clicked.");
        }
    }
}