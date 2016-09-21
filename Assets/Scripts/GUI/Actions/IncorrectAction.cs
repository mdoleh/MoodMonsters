// Generic class to handle incorrect action choices
// Allows you to set the animations that are triggered
// during and after the character dialogue
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