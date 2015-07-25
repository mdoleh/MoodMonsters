using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class TemperTantrum : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            anim.SetTrigger("Tantrum");
        }
    }
}