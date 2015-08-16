using UnityEngine;
using System.Collections;
using Globals;
using ScaredScene;

namespace ScaredScene
{
    public class Support : DefaultActionBase
    {
        public GameObject PASSLetter;

        protected override void DialogueAnimation()
        {
            //        anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            //            anim.SetTrigger("Idle");
            sceneReset.sceneToLoadIncorrect = "ScaredSceneSmallCityParentSolveActionsMenu";
            GUIHelper.GetPreviousGUI("ParentSolveCanvas" + GameFlags.ParentGender).enabled = true;
            GUIHelper.NextGUI();
        }

        protected override void BeforeExplanation()
        {
            base.BeforeExplanation();
            PASSLetter.SetActive(true);
            PASSLetter.GetComponent<Animator>().SetTrigger("BlowUp");
        }

        protected override void BeforeAdditionalExplanation()
        {
            base.BeforeAdditionalExplanation();
            PASSLetter.GetComponent<Animator>().SetTrigger("Empty");
        }
    }
}