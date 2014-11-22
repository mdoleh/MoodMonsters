using UnityEngine;
using System.Collections;

namespace StartScreen
{
    public class Angry : MonoBehaviour
    {
        public void ButtonClick() {
            Application.LoadLevel("AngryScene");
        }
    }
}