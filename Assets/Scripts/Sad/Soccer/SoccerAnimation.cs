using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class SoccerAnimation : MonoBehaviour
    {
        public SoccerBallMovement soccerBall;
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void ShiftIdle()
        {
            anim.SetTrigger("Idle");
        }

        public void KickBallUp()
        {
            soccerBall.KickBallUp();
        }

        public void KickForward()
        {
            anim.SetTrigger("Idle");
            StartCoroutine(KickBallForward());
        }

        public void KickForwardEvent()
        {
            soccerBall.KickBallForward();
        }

        private IEnumerator KickBallForward()
        {
            yield return new WaitForSeconds(1f);
            anim.SetTrigger("KickForward");
        }
    }
}