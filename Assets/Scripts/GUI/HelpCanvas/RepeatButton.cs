using UnityEngine;
using System.Collections;

namespace HelpGUI
{
    public class RepeatButton : ButtonSelect {

        protected override void DoubleClickAction()
        {
            Utilities.PlayAudio(GUIDetect.GetCurrentGUI().GetComponent<AudioSource>());
        }
    }
}