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
                anim.SetBool("IsIdle", false);
                anim.SetTrigger("IsTakingIPad");
                other.SetBool("IsUsingIPad", false);
                other.SetTrigger("IsLosingIPad");
            }
            if (anim.GetBool("IsUsingIPad")) StartGUI();
        }

        public void StartUsingIPad() {
            anim.SetBool("IsUsingIPad", true);
            other.SetBool("IsIdle", true);
        }

        void StartGUI()
        {
            if (GUIon) return; // don't want to execute multiple times
            GUIon = true;
            for (int ii = 0; ii < GUI.Length; ++ii)
            {
                if (GUI[ii].name == "EmotionsCanvas")
                {
                    GUI[ii].GetComponent<Canvas>().enabled = true;
                    return;
                }
            }
        }
    }
}