using UnityEngine;
using System.Collections;

namespace PhysicalGUI
{
    public class CorrectAnswer : ButtonDragDrop
    {
        protected override void Awake()
        {
            base.Awake();
            CORRECT_AMOUNT = 3;
        }

        public override void ButtonDown()
        {
            base.ButtonDown();
            Debug.Log("Correct answer clicked");
        }

        public override void SubmitAnswer()
        {
            Debug.Log("Correct answer submitted");
            GameObject.Destroy(gameObject);
            base.SubmitAnswer();
        }
    }
}