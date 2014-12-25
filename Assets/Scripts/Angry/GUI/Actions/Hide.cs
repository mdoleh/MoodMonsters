using UnityEngine;
using System.Collections;

namespace AngryScene
{
    namespace ActionsGUI
    {
        public class Hide : ButtonDragDrop
        {
            public AngryScene.RunAway runAway;

            public override void ButtonDown()
            {
                base.ButtonDown();
                Debug.Log("Hide clicked");
            }

            public override void SubmitAnswer()
            {
                base.SubmitAnswer();
                Debug.Log("Hide submitted");
                runAway.StartTurning();
                HideGUI();
            }
        }
    }
}

