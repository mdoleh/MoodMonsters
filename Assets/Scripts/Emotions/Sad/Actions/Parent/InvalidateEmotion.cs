using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class InvalidateEmotion : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
//            anim.SetTrigger("Invalidate");
        }
    }
}