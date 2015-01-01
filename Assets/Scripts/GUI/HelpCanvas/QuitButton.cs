using UnityEngine;
using System.Collections;

namespace HelpGUI
{
    public class QuitButton : HelpBase
    {

        protected override void DoubleClickAction()
        {
            Utilities.LoadScene("TitleScreen");
        }
    }
}