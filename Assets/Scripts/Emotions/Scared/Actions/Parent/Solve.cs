using UnityEngine;
using System.Collections;

namespace ScaredScene
{
    public class Solve : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            anim.SetTrigger("Solve");
        }
    }
}