using UnityEngine;
using System.Collections;

namespace AngryScene
{
    namespace PhysicalGUI
    {
        public class WrongAnswer : ButtonDragDrop
        {

            public override void ButtonDown()
            {
                base.ButtonDown();
                Debug.Log("Wrong answer clicked");
            }

            public override void SubmitAnswer()
            {
                base.SubmitAnswer();
                Debug.Log("Wrong answer submitted");
            }
        }
    }
}
