using UnityEngine;
using System.Collections;

namespace ScaredScene
{
    public class InvalidateFear : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            anim.SetTrigger("Invalidate");
        }
    }
}