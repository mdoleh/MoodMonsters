using UnityEngine;
using System.Collections;

namespace AngryScene
{
    namespace ActionsGUI
    {
        public class Express : ButtonDragDrop
        {
            public AngryScene.ActionBase share;

            public override void ButtonDown()
            {
                base.ButtonDown();
                Debug.Log("Express clicked");
            }

            public override void SubmitAnswer()
            {
                base.SubmitAnswer();
                Debug.Log("Express submitted");
                share.StartAction();
                HideGUI();
            }
        }
    }
}