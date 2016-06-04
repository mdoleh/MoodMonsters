namespace BlendsScene
{
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