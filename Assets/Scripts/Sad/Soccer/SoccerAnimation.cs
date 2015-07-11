using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class SoccerAnimation : MonoBehaviour
    {
        public SoccerBallMovement soccerBall;

        public void KickBallUp()
        {
            soccerBall.KickBallUp();
        }

        public void KickForward()
        {
            GetComponent<Animator>().SetTrigger("KickForward");
            soccerBall.KickBallForward();
        }
    }
}