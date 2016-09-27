using UnityEngine;
using System.Collections;

namespace SadScene
{
    // Incorrect option choice for EmotionActions
    public class TemperTantrum : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            anim.SetTrigger("Tantrum");
        }

        public void SadIdleEvent()
        {
            anim.SetTrigger("Idle");
        }
    }
}