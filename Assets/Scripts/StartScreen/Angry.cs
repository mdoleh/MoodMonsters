using UnityEngine;
using System.Collections;

namespace StartScreen
{
    public class Angry : StartMenuButton
    {
        protected void ButtonClick() {
            base.ButtonClick();
            Debug.Log("Angry clicked");
        }
    }
}