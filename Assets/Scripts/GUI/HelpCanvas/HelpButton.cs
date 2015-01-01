using UnityEngine;
using System.Collections;

namespace HelpGUI
{
    public class HelpButton : HelpBase
    {

        protected override void DoubleClickAction()
        {
            Debug.Log("Help clicked.");
        }
    }
}