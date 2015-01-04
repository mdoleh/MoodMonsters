﻿using UnityEngine;
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

        void StartGUI()
        {
            if (GUIon) return; // don't want to execute multiple times
            GUIon = true;
            for (int ii = 0; ii < GUI.Length; ++ii)
            {
//                if (GUI[ii].name == "EmotionsCanvas")
                if (GUI[ii].name == "TutorialCanvas")
                {
                    GUI[ii].GetComponent<Canvas>().enabled = true;
                    runTutorial.Initialize();
//                    Utilities.PlayAudio(GUI[ii].GetComponent<AudioSource>());
                    return;
                }
            }
        }
    }
}