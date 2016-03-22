using UnityEngine;

namespace HappyScene
{
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
            prizeWinner.SetTrigger("Idle");
            nonWinner.ReturnToOriginalSpot();
        }
    }
}