using UnityEngine;
using System.Collections;

namespace StartScreen
{
    public class Scared : StartMenuButton
    {
        protected void ButtonClick() {
            base.ButtonClick();
            Debug.Log("Scared clicked");
        }
    }
}