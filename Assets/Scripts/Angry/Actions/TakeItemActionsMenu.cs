using UnityEngine;
using System.Collections;
using Globals;

namespace AngryScene
{
    public class TakeItemActionsMenu : MonoBehaviour
    {

        public GameObject GUI;
        Animator anim;
        bool GUIon = false;
        public Animator other;
        float timer = 0.0f;

        public void Awake()
        {
            anim = GetComponent<Animator>();
        }

        void Start()
        {
            Timeout.StopTimers();
            Timeout.SetRepeatAudio(GUI.GetComponent<AudioSource>());
        }

        void Update()
        {
            timer += Time.deltaTime;
            if (timer > 2.0f) // simulate dialogue
            {
                StartUsingIPad();
                if (anim.GetBool("IsUsingIPad")) StartGUI();
            }
        }

        public void StartUsingIPad() {
            anim.SetBool("IsUsingIPad", true);
            other.SetTrigger("IsAngry");
        }

        void StartGUI()
        {
            if (GUIon) return; // don't want to execute multiple times
            GUIon = true;
            GUI.GetComponent<Canvas>().enabled = true;
            Utilities.PlayAudio(GUI.GetComponent<AudioSource>());
            Timeout.StartTimers();
        }

        // these are only here so the animation events don't complain
        public void MoveIpad() {}
        public void TiltIpadUp() {}
        public void ShiftToLeftHand() {}
    }
}