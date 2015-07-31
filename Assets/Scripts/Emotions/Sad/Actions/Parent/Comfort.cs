using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class Comfort : DefaultActionBase
    {
        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
//            anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            base.AfterDialogue();
//            anim.SetTrigger("Idle");
            sceneReset.sceneToLoadIncorrect = "SadSceneSmallCitySituationActionsMenu";
            GUIHelper.NextGUI();
        }
    }
}