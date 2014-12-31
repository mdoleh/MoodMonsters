using UnityEngine;
using System.Collections;

namespace StartScreen
{
    public class Sad : StartMenuButton
    {
        protected void ButtonClick() {
            base.ButtonClick();
            Debug.Log("Sad clicked");
        }
    }
}