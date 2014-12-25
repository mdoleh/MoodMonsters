using UnityEngine;
using System.Collections;

namespace AngryScene
{
    namespace ActionsGUI
    {
        public class Express : ButtonDragDrop
        {
            public AngryScene.Share share;

            public override void ButtonDown()
            {
                base.ButtonDown();
                Debug.Log("Express clicked");
            }

            public override void SubmitAnswer()
            {
                base.SubmitAnswer();
                Debug.Log("Express submitted");
                share.StartTalking();
                HideGUI();
                //NextGUI();
            }
        }
    }
}