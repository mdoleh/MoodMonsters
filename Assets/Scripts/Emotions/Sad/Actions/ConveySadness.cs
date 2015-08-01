﻿using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class ConveySadness : CorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            base.AfterDialogue();
            anim.SetTrigger("Idle");
            sceneReset.sceneToLoadIncorrect = "SadSceneSmallCityParentActionsMenu";
            GameObject.Find("EmotionActionsCanvas").GetComponent<Canvas>().enabled = true;
            GUIHelper.NextGUI();
        }
    }
}