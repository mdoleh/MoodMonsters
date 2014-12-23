using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class TakeItBack : ActionBase
    {
        public Animator other;
        Animator anim;

        public void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void StartTaking()
        {
            anim.SetTrigger("IsActingOut");
            other.SetTrigger("IsLosingIPad");
        }

        public void StartUsingIPad()
        {
            anim.SetBool("IsUsingIPad", true);
            other.SetTrigger("IsSad");
            startTimer = true;
            eventTrigger = true;
        }
    }
}