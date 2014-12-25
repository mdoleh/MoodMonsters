using UnityEngine;
using System.Collections;

namespace StartScreen
{
    public class Happy : StartMenuButton
    {
        protected void ButtonClick() {
            base.ButtonClick();
            Debug.Log("Happy clicked");
        }
    }
}