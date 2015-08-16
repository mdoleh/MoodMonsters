using UnityEngine;
using System.Collections;
using Globals;

namespace SadScene
{
    public class Support : DefaultActionBase
    {
        public GameObject PASSLetter;

        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
//            anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            base.AfterDialogue();
//            anim.SetTrigger("Idle");
            if (!GameFlags.AdultIsPresent)
            {
                GetComponent<Solve>().StartDefaultAction();
                return;
            }
            sceneReset.sceneToLoadIncorrect = "SadSceneSmallCityParentSolveActionsMenu";
            GUIHelper.GetPreviousGUI("ParentSolveCanvas" + GameFlags.ParentGender).enabled = true;
            GUIHelper.NextGUI();
        }

        protected override void BeforeExplanation()
        {
            base.BeforeExplanation();
            if (!GameFlags.AdultIsPresent) return;
            PASSLetter.SetActive(true);
            PASSLetter.GetComponent<Animator>().SetTrigger("BlowUp");
        }

        protected override void BeforeAdditionalExplanation()
        {
            base.BeforeAdditionalExplanation();
            if (!GameFlags.AdultIsPresent) return;
            PASSLetter.GetComponent<Animator>().SetTrigger("Empty");
        }
    }
}