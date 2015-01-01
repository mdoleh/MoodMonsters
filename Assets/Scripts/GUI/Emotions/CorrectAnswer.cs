using UnityEngine;
using System.Collections;

namespace EmotionsGUI
{
    public class CorrectAnswer : ButtonDragDrop
    {
        protected override void Awake()
        {
            base.Awake();
            CORRECT_AMOUNT = 1;
        }

        public override void ButtonDown()
        {
            base.ButtonDown();
            Debug.Log("Correct answer clicked");
        }

        public override void SubmitAnswer()
        {
            base.SubmitAnswer();
            Debug.Log("Correct answer submitted");
        }
    }
}