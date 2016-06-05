namespace SadScene
{
    public class ConveySadness : CorrectActionBase
    {
        public PassTablet passTablet;

        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            base.AfterDialogue();
            anim.SetTrigger("Idle");
            passTablet.SwitchToParent();
        }
    }
}