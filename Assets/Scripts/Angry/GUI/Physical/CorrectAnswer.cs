using UnityEngine;
using System.Collections;

namespace AngryScene
{
    namespace PhysicalGUI
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
                Debug.Log("Correct answer submitted");
                GameObject.Destroy(gameObject);
                correctCount += 1;
                base.SubmitAnswer();
            }
        }
    }
}