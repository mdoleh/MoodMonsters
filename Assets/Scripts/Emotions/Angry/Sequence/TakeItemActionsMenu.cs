using UnityEngine;
using System.Collections;
using Globals;

namespace AngryScene
{
    public class TakeItemActionsMenu : TakeItem
    {
        public GameObject GUI;
        bool GUIon = false;

        void Start()
        {
            Timeout.StopTimers();
            Timeout.SetRepeatAudio(GUI.GetComponent<AudioSource>());
            StartCoroutine(StartUsingIPad());
        }

        public IEnumerator StartUsingIPad()
        {
            yield return new WaitForSeconds(2f);
            anim.SetBool("IsUsingIPad", true);
            other.SetTrigger("IsAngry");
            if (anim.GetBool("IsUsingIPad")) StartGUI();
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
        public override void MoveIpad() {}
        public override void ShiftToLeftHand() { }
    }
}