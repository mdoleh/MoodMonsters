using UnityEngine;
using System.Collections;

namespace HelpGUI
{
    public class RepeatButton : HelpBase
    {
         protected override void DoubleClickAction()
        {
            base.DoubleClickAction();
            Utilities.PlayAudio(GUIHelper.GetCurrentGUI().GetComponent<AudioSource>());
        }
    }
}