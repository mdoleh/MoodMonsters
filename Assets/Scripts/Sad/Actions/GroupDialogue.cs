using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class GroupDialogue : MonoBehaviour
    {
        public AudioSource cantPlay;
        public AudioSource dontGetToPlay;
        public OutsideGroupDialogue otherCharacter;

        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void ExplainCantPlay()
        {
            GetComponent<CapsuleCollider>().enabled = false;
            anim.SetTrigger("CantPlay");
        }

        public void TriggerCantPlayDialogue()
        {
            anim.SetTrigger("CantPlay");
            Utilities.PlayAudio(cantPlay);
        }

        public void PlayNowDialogue()
        {
            anim.SetTrigger("Idle");
            otherCharacter.PlayNowDialogue();
        }

        public void HaveToWait()
        {
            Utilities.PlayAudio(dontGetToPlay);
            anim.SetTrigger("HaveToWait");
        }

        public void TriggerWalkAway()
        {
            anim.SetTrigger("Idle");
            otherCharacter.WalkAway();
        }
    }
}