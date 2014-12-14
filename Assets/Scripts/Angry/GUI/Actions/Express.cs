﻿using UnityEngine;
using System.Collections;

namespace AngryScene
{
    namespace ActionsGUI
    {
        public class Express : ButtonDragDrop
        {

            public override void ButtonDown()
            {
                base.ButtonDown();
                Debug.Log("Express clicked");
            }

            public override void SubmitAnswer()
            {
                base.SubmitAnswer();
                Debug.Log("Express submitted");
                //NextGUI();
            }
        }
    }
}