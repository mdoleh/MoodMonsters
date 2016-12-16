using UnityEngine;
using System.Collections;

namespace AngryScene
{
    // Holds all of the behaviors to trigger on animation events
    // Used only on Ty
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

        public void TriggerAngryFoldedArmsEvent()
        {
            anim.SetTrigger("IsAngry");
        }

        public void MoveIpadUnderArm()
        {
            var ipad = GameObject.Find("iPad");
            ipad.transform.localPosition = new Vector3(0.04f, -0.073f, 0.049f);
            ipad.transform.localRotation = Quaternion.Euler(352.4399f, 357.2535f, 10.56083f);
        }

        public void MoveIpadForSharing()
        {
            var ipad = GameObject.Find("iPad");
            ipad.transform.localPosition = new Vector3(-0.071f, 0.192f, 0.05f);
            ipad.transform.localRotation = Quaternion.Euler(7.655785f, 0.08176757f, 10.56322f);
        }
    }
}

