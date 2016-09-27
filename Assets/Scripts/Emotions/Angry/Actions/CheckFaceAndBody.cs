using UnityEngine;
using System.Collections;

namespace AngryScene
{
    // Correct option choice for EmotionActions
    public class CheckFaceAndBody : CorrectActionBase
    {
        protected override void AfterDialogue()
        {
            GUIHelper.NextGUI();
        }
    }
}