namespace BlendsScene
{
    // Incorrect option choice for Emotion and Situation Actions
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