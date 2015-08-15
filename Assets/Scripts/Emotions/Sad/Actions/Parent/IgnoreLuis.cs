using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class IgnoreLuis : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
//            anim.SetTrigger("Ignore");
        }
    }
}