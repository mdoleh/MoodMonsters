using System;
using System.Collections;
using SadScene;
using UnityEngine;

namespace TitleScreen
{
    public class TitleWave : GroupSoccerAnimation
    {
        public int counter = 0;

        private void clearCounter()
        {
            counter = 0;
        }

        public override void KickForward()
        {
            soccerBall.NeutralizeForce();
            ++counter;
            if (counter >= 2)
            {
                StartCoroutine(waveAnimation(() => base.KickForward()));
            }
            else base.KickForward();
        }

        private IEnumerator waveAnimation(Action callBack)
        {
            anim.SetTrigger("Wave");
            yield return new WaitForSeconds(3f);
            anim.SetTrigger("Idle");
            clearCounter();
            callBack();
        }
    }
}