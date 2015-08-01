using UnityEngine;
using System.Collections;
using Globals;

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
            GameObject.Find("ParentActionsCanvas" + GameFlags.ParentGender).GetComponent<Canvas>().enabled = true;
            GUIHelper.NextGUI();
        }
    }
}