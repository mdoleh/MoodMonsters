namespace ScaredScene
{
    // Incorrect option choice for ParentSupport
    public class Distract : IncorrectActionBase
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