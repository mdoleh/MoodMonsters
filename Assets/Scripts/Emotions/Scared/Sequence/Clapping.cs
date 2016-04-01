﻿using UnityEngine;
using System.Collections;
using ScaredScene;

namespace ScaredScene
{
    public class Clapping : MonoBehaviour
    {
        public Animator anim;
        public ExplainFear fearfulCharacter;
        public Conversation fearlessCharacter;
        public AudioSource successDialogue;
        public AudioSource explanationAudio;

        public void StartClapping()
        {
            anim.SetTrigger("Clap");
            fearlessCharacter.ClappingAnimation();
            StartCoroutine(PlayClappingDialogue());
        }

        private IEnumerator PlayClappingDialogue()
        {
            Utilities.PlayAudio(successDialogue);
            yield return new WaitForSeconds(successDialogue.clip.length);
            Utilities.PlayAudio(explanationAudio);
            fearfulCharacter.GetComponent<Rigidbody>().constraints =
                fearfulCharacter.GetComponent<Rigidbody>().constraints | RigidbodyConstraints.FreezePositionY;
            yield return new WaitForSeconds(explanationAudio.clip.length);
            fearfulCharacter.gameObject.GetComponent<ExplainFear>().GoToMiniGame();
        }
    }
}