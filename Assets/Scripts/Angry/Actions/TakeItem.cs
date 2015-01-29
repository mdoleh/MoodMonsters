using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class TakeItem : MonoBehaviour
    {

        GameObject[] GUI;
        Animator anim;
        bool GUIon = false;
        public Animator other;
        public RunTutorial runTutorial;
        float timer = 0.0f;

        public void Awake()
        {
            GUI = GameObject.FindGameObjectsWithTag("GUI");
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
            ipad.transform.localPosition = new Vector3(0.29728f, -0.17582f, 0.045597f);
            ipad.transform.localRotation = Quaternion.Euler(328.4845f, 3.768595f, 272.94f);
        }

        public void TiltIpadUp()
        {
            var ipad = GameObject.Find("iPad");
            ipad.transform.localPosition = new Vector3(0.20047f, -0.14279f, 0.18211f);
            ipad.transform.localRotation = Quaternion.Euler(332.2167f, 316.2656f, 281.1285f);
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
            if (GUIon) return; // don't want to execute multiple times
            GUIon = true;
            for (int ii = 0; ii < GUI.Length; ++ii)
            {
                if (GUI[ii].name == "TutorialCanvas")
                {
                    GUI[ii].GetComponent<Canvas>().enabled = true;
                    runTutorial.Initialize();
                    return;
                }
            }
        }
    }
}