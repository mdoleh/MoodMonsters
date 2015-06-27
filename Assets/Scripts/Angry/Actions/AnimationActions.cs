using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class AnimationActions : MonoBehaviour
    {
        private Animator anim;
        
        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void TriggerStandToSit()
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            anim.SetTrigger("IsSharing");
        }

        public void TriggerSitIdle()
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            anim.SetTrigger("IsSharing");
        }

        public void TriggerSadIdle()
        {
            anim.SetTrigger("IsSad");
        }
    }
}

