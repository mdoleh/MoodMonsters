using UnityEngine;
using System.Collections;

namespace AngryScene
{
    namespace EmotionsGUI
    {
        public class CorrectAnswer : ButtonDragDrop
        {

            public override void ButtonDown()
            {
                base.ButtonDown();
                Debug.Log("Correct answer clicked");
            }

            public override void SubmitAnswer()
            {
                base.SubmitAnswer();
                Debug.Log("Correct answer submitted");
                NextGUI();
            }
        }
    }
}