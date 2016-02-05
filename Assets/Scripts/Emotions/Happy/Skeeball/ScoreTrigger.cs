using UnityEngine;

namespace HappyScene
{
    public class ScoreTrigger : MonoBehaviour
    {
        public SkeeballThrow thrower;
        public SkeeballScore scoreKeeper;
        public GoalChooser goalChooser;
        public AudioSource bonusSound;
        public AudioSource defaultSound;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BallAnimation>() != null)
            {
                if (gameObject.name.Contains(GoalChooser.correctGoal.name))
                {
                    scoreKeeper.IncreaseScore(100);
                    Utilities.PlayAudio(bonusSound);
                }
                else
                {
                    scoreKeeper.IncreaseScore(50);
                    Utilities.PlayAudio(defaultSound);
                }
                resetBall(other);
            }
        }

        private void resetBall(Collider other)
        {
            thrower.ResetForNextThrow(other.transform);
            if (goalChooser != null) goalChooser.HideAllHighlighers();
        }
    }
}