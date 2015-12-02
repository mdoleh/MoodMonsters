using UnityEngine;
using System.Collections;

namespace ScaredScene
{
    public class Distract : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            anim.SetTrigger("Distract");
        }
    }
}