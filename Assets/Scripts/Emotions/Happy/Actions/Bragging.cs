using UnityEngine;

namespace HappyScene
{
    public class Bragging : IncorrectActionBase
    {
        public AutomatedFollowPlayer otherCharacter;

        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            anim.SetTrigger("Brag");
        }

        protected override void AfterDialogue()
        {
            base.AfterDialogue();
            otherCharacter.ShiftSad();
            anim.SetTrigger("Idle");
        }
    }
}