namespace BlendsScene
{
    public class Argue : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            anim.SetTrigger("Ask");
        }

        protected override void AfterDialogue()
        {
            anim.SetTrigger("Idle");    
        }
    }
}