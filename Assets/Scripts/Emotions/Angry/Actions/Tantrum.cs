using UnityEngine;
using System.Collections;

namespace AngryScene
{
    // Incorrect option choice for EmotionActions
    public class Tantrum : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            anim.SetTrigger("Complain");
        }
    }
}