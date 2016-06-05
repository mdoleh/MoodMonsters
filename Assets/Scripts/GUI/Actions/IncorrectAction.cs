public class IncorrectAction : IncorrectActionBase
{
    public string dialogueAnimation;
    public string afterDialogueAnimation;

    protected override void DialogueAnimation()
    {
        anim.SetTrigger(dialogueAnimation);
    }

    protected override void AfterDialogue()
    {
        anim.SetTrigger(afterDialogueAnimation);
    }
}