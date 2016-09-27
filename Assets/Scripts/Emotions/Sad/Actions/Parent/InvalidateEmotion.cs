using UnityEngine;
using System.Collections;

namespace SadScene
{
    // Incorrect option choice for ParentPayAttentionAsk
    public class InvalidateEmotion : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            anim.SetTrigger("Invalidate");
        }

        protected override void AfterDialogue()
        {
            anim.SetTrigger("Idle");
        }
    }
}