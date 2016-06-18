using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class Tantrum : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            anim.SetTrigger("Complain");
        }
    }
}