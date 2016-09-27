namespace BlendsScene
{
    // Incorrect option choice for Emotion and Situation Actions
    public class RefuseToGo : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            anim.SetTrigger("Angry");
        }

        protected override void AfterDialogue()
        {
            anim.SetTrigger("Idle");
        }
    }
}