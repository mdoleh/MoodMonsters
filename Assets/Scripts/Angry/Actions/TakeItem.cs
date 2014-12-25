using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class TakeItem : MonoBehaviour
    {

        GameObject[] GUI;
        Animator anim;
        bool GUIon = false;
        bool animationsTriggered = false;
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
            if (timer > 5.0f && !animationsTriggered) // simulate dialogue
            {
                anim.SetBool("IsIdle", false);
                anim.SetTrigger("IsTakingIPad");
                other.SetBool("IsUsingIPad", false);
                other.SetTrigger("IsLosingIPad");
                animationsTriggered = true;
            }
            if (anim.GetBool("IsUsingIPad")) StartGUI();
        }

        public void StartUsingIPad() {
            anim.SetBool("IsUsingIPad", true);
            other.SetTrigger("IsAngry");
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
                    Utilities.PlayAudio(GUI[ii].GetComponent<AudioSource>());
                    return;
                }
            }
        }
    }
}