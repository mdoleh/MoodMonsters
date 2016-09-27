using UnityEngine;

namespace HappyScene
{
    // Hint that triggers a custom animation and movement on
    // the characters to make them high five each other
    public class HighFiveHint : HintBase
    {
        public AudioSource hintToPlay;
        public AutomatedFollowPlayer nonWinner;
        public Animator prizeWinner;

        public override void ShowHint()
        {
            nonWinner.GetComponent<Animator>().SetTrigger("Walk");
            nonWinner.StartMoving();
            Utilities.PlayAudio(hintToPlay);
        }

        public override void NotifyCanvasChange()
        {
            if (!prizeWinner.GetCurrentAnimatorStateInfo(1).IsName("Excited"))
                prizeWinner.SetTrigger("Idle");
            nonWinner.ReturnToOriginalSpot();
        }
    }
}