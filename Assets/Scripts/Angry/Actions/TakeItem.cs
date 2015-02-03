using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class TakeItem : MonoBehaviour
    {
        private GameObject emotionsGUI;
        private Animator anim;
        public Animator other;
        private float timer = 0.0f;

        public void Awake()
        {
            emotionsGUI = GameObject.Find("EmotionsCanvas");
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            timer += Time.deltaTime;
            if (timer > 5.0f) // simulate dialogue
            {
                if (!anim.GetBool("IsUsingIPad"))
                {
                    anim.SetBool("IsIdle", false);
                    anim.SetTrigger("IsTakingIPad");
                    other.SetBool("IsUsingIPad", false);
                    other.SetTrigger("IsLosingIPad");
                }
            }
            if (anim.GetBool("IsUsingIPad")) StartGUI();
        }

        public void StartUsingIPad() {
            anim.SetBool("IsUsingIPad", true);
            other.SetTrigger("IsAngry");
        }

        public void MoveIpad()
        {
            var ipad = GameObject.Find("iPad");
            var hand = GameObject.Find("Boy:RightHand");
            ipad.transform.parent = hand.transform;
            ipad.transform.localPosition = new Vector3(0.16965f, -0.18118f, 0.20516f);
            ipad.transform.localRotation = Quaternion.Euler(0.5527962f, 278.4825f, 301.6339f);
        }

        public void ShiftToLeftHand()
        {
            var ipad = GameObject.Find("iPad");
            var hand = GameObject.Find("Boy:LeftHand");
            ipad.transform.parent = hand.transform;
            ipad.transform.localPosition = new Vector3(-0.15317f, -0.17448f, 0.1441f);
            ipad.transform.localRotation = Quaternion.Euler(334.0472f, 53.15136f, 93.76542f);
        }

        void StartGUI()
        {
            emotionsGUI.GetComponent<Canvas>().enabled = true;
            Utilities.PlayAudio(emotionsGUI.GetComponent<AudioSource>());
            enabled = false;
        }
    }
}