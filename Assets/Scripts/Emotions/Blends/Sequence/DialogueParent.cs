using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

namespace BlendsScene
{
    public class DialogueParent : MonoBehaviour
    {
        public AudioSource weAreMoving;
        public AudioSource cantSeeFriends;
        public AudioSource newJobFarAway;
        public DialogueKid[] children;
        public PassTablet passTablet;
        
        private DialogueKid currentChild;
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
            currentChild =
                children.ToList()
                    .Find(x => x.transform.parent.name.ToLower().Contains(GameFlags.PlayerGender.ToLower()));
        }

        public void ExplainMoving()
        {
            StartCoroutine(playAudio(weAreMoving, () => anim.SetTrigger("TalkingHappy"), () =>
            {
                currentChild.CanSeeFriends();
                anim.SetTrigger("Idle");
            }));
        }

        public void CantSeeFriends()
        {
            StartCoroutine(playAudio(cantSeeFriends, () =>
            {
                anim.SetTrigger("TalkingSad");
                anim.speed = cantSeeFriends.clip.length / anim.GetCurrentAnimatorStateInfo(0).length;
            }, () =>
            {
                anim.speed = 1;
                anim.SetTrigger("Idle");
                GUIHelper.NextGUI();
            }));
        }

        public void ExplainNewJob()
        {
            StartCoroutine(playAudio(newJobFarAway, () => anim.SetTrigger("TalkingSad"), () =>
            {
                anim.SetTrigger("Idle");
                passTablet.SwitchToParent();
            }));
        }

        

        private IEnumerator playAudio(AudioSource source, Action preAudioAction, Action postAudioAction)
        {
            yield return new WaitForSeconds(0.5f);
            preAudioAction();
            Utilities.PlayAudio(source);
            yield return new WaitForSeconds(source.clip.length);
            postAudioAction();
        }
    }
}