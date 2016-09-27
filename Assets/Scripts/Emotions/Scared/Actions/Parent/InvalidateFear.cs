namespace ScaredScene
{
    // Incorrect option choice for ParentPayAttentionAsk
    public class InvalidateFear : IncorrectActionBase
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