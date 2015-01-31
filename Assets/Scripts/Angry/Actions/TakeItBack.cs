using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class TakeItBack : ActionBase
    {
        public Animator other;
        Animator anim;
        private bool takingTriggered = false;

        public void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void StartTaking()
        {
            takingTriggered = true;
            anim.SetTrigger("IsActingOut");
            other.SetTrigger("IsLosingIPad");
        }

        public void MoveIpad()
        {
            if (!takingTriggered) return; 
            var ipad = GameObject.Find("iPad");
            var hand = GameObject.Find("Bip01 R Hand");
            ipad.transform.parent = hand.transform;
            ipad.transform.localPosition = new Vector3(-0.18749f, 0.03664f, 0.11059f);
            ipad.transform.localRotation = Quaternion.Euler(1.644903f, 68.03117f, 120.0284f);
        }

        public void ShiftToLeftHand()
        {
            if (!takingTriggered) return; 
            var ipad = GameObject.Find("iPad");
            var hand = GameObject.Find("Bip01 L Hand");
            ipad.transform.parent = hand.transform;
            ipad.transform.localPosition = new Vector3(-0.17578f, 0.18183f, -0.043791f);
            ipad.transform.localRotation = Quaternion.Euler(10.98124f, 156.6697f, 278.0708f);
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