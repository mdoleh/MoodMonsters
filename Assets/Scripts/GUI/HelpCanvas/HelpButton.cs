using UnityEngine;

namespace HelpGUI
{
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