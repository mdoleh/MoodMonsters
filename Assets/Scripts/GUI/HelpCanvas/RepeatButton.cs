using Globals;

namespace HelpGUI
{
    // Plays the Repeat Audio from the Timer
    // typically the last given instruction by the game
    public class RepeatButton : HelpBase
    {
        protected override void DoubleClickAction()
        {
            base.DoubleClickAction();
            Utilities.PlayAudio(Timeout.GetRepeatAudio());
        }
    }
}