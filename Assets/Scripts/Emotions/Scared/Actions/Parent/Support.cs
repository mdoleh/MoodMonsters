using UnityEngine;
using System.Collections;
using Globals;
using ScaredScene;

namespace ScaredScene
{
    public class Support : DefaultActionBase
    {
        protected override void DialogueAnimation()
        {
            //        anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            //            anim.SetTrigger("Idle");
            GUIHelper.GetPreviousGUI("ParentSolveCanvas" + GameFlags.ParentGender).enabled = true;
            GUIHelper.NextGUI();
        }
    }
}