using UnityEngine;
using System.Collections;

namespace HelpGUI
{
    // Quit button behavior, takes the player back to the Main Menu
    public class QuitButton : HelpBase
    {
        protected override void DoubleClickAction()
        {
            base.DoubleClickAction();
            Utilities.LoadScene("MainMenuScreen");
        }
    }
}