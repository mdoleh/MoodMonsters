using UnityEngine;

namespace GameIntro
{
    public class AngryAnimation : MonoBehaviour
    {
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void ShiftAngry()
        {
            anim.SetTrigger("Shift");
        }
    }
}