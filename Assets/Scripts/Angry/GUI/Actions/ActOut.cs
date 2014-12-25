using UnityEngine;
using System.Collections;

namespace AngryScene
{
    namespace ActionsGUI
    {
        public class ActOut : ButtonDragDrop
        {
            public AngryScene.TakeItBack takeItBack;

            public override void ButtonDown()
            {
                base.ButtonDown();
                Debug.Log("ActOut clicked");
            }

            public override void SubmitAnswer()
            {
                base.SubmitAnswer();
                Debug.Log("ActOut submitted");
                takeItBack.StartTaking();
                HideGUI();
                //NextGUI();
            }
        }
    }
}