using UnityEngine;
using System.Collections;

namespace HelpGUI
{
    public class HelpButton : ButtonSelect
    {

        protected override void DoubleClickAction()
        {
            Debug.Log("Help clicked.");
        }
    }
}