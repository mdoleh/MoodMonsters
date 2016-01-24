using UnityEngine;

namespace HappyScene
{
    public class ScoreTrigger : MonoBehaviour
    {
        public SkeeballCharacterMovement thrower;
        public SkeeballScore scoreKeeper;
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
            other.transform.position = new Vector3(214.304f, 4.73f, 165.337f);
            other.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            thrower.ResetForNextThrow(other.transform);
        }
    }
}