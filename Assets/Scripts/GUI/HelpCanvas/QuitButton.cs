using UnityEngine;
using System.Collections;

namespace HelpGUI
{
    public class QuitButton : ButtonSelect
    {

        protected override void DoubleClickAction()
        {
            Utilities.LoadScene("TitleScreen");
        }
    }
}