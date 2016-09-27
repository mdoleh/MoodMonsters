namespace SadScene
{
    // Incorrect option choice for EmotionActions
    public class ConveySadness : CorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            base.AfterDialogue();
            anim.SetTrigger("Idle");
            GUIHelper.NextGUI();
        }
    }
}