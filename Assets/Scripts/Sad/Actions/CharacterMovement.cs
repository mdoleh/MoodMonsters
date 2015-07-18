using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class CharacterMovement : MonoBehaviour
    {
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void WalkAwayEvent()
        {
            anim.SetTrigger("WalkAway");
            GetComponent<OutsideGroupSoccerAnimation>().SetWalkAwaySpeed();
        }
    }
}

