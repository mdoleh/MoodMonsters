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
        public DialogueKid[] children;

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
            anim.SetTrigger("TalkingHappy");
            StartCoroutine(playAudio(weAreMoving, () =>
            {
                currentChild.CanSeeFriends();
                anim.SetTrigger("Idle");
            }));
        }

        public void CantSeeFriends()
        {
            anim.SetTrigger("TalkingSad");
            anim.speed = cantSeeFriends.clip.length / anim.GetCurrentAnimatorStateInfo(0).length;
            StartCoroutine(playAudio(cantSeeFriends, () =>
            {
                anim.speed = 1;
                anim.SetTrigger("Idle");
                GUIHelper.NextGUI();
            }));
        }

        private IEnumerator playAudio(AudioSource source, Action postAudioAction)
        {
            Utilities.PlayAudio(source);
            yield return new WaitForSeconds(source.clip.length);
            postAudioAction();
        }
    }
}