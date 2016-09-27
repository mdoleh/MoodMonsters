using UnityEngine;
using System.Collections;
using SadScene;

namespace SadScene
{
    // Used on colliders that determine where Luis should stop when his position is being reset
    public class RetryPoint : MonoBehaviour
    {
        public static GameObject PreviousRetryPoint;
        public OutsideGroupSoccerBallMovement soccerBall;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<OutsideGroupSoccerAnimation>() != null)
            {
                other.GetComponent<OutsideGroupSoccerAnimation>().StopWalkingBackwards();
                gameObject.SetActive(false);
                soccerBall.ResetPosition();
                LaneAppear.shouldShowLanes = true;
                PreviousRetryPoint = gameObject;
            }
        }
    }
}