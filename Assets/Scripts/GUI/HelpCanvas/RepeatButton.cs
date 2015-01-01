using UnityEngine;
using System.Collections;

namespace HelpGUI
{
    public class RepeatButton : HelpBase {

        protected override void DoubleClickAction()
        {
            Utilities.PlayAudio(GUIDetect.GetCurrentGUI().GetComponent<AudioSource>());
        }
    }
}