using UnityEngine;
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

        public void PlayNowDialogue()
        {
            anim.SetTrigger("PlayNow");
            Utilities.PlayAudio(noneAreHere);
        }

        public void HaveToWait()
        {
            anim.SetTrigger("Idle");
            otherCharacter.HaveToWait();
        }

        public void WalkAway()
        {
            
        }
    }
}