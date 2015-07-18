﻿using UnityEngine;
using System.Collections;
using Globals;

namespace SadScene
{
    public class OutsideGroupDialogue : MonoBehaviour
    {
        public AudioSource canIPlay;
        public AudioSource noneAreHere;
        public GroupDialogue otherCharacter;

        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void StartDialogue()
        {
            anim.SetTrigger("CanIPlay");
            StartCoroutine(DelayPlayAudio(canIPlay));
        }

        private IEnumerator DelayPlayAudio(AudioSource source)
        {
            Timeout.StopTimers();
            yield return new WaitForSeconds(1f);
            Utilities.PlayAudio(source);
        }

        public void ExplainCantPlay()
        {
            anim.SetTrigger("Idle");
            otherCharacter.ExplainCantPlay();
        }

        public void NoneAreHereDialogue()
        {
            anim.SetTrigger("NoneAreHere");
            Utilities.PlayAudio(noneAreHere);
        }

        public void DontGetToPlay()
        {
            anim.SetTrigger("Idle");
            otherCharacter.DontGetToPlay();
        }

        public void WalkAway()
        {
            
        }
    }
}