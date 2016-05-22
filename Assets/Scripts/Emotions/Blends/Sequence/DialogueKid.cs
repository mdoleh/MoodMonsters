using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

namespace BlendsScene
{
    public class DialogueKid : MonoBehaviour
    {
        public AudioSource canSeeFriends;
        public DialogueParent[] parents;

        private DialogueParent currentParent;
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
            currentParent =
                parents.ToList().Find(x => x.gameObject.name.ToLower().Contains(GameFlags.ParentGender.ToLower()));
        }

        public void CanSeeFriends()
        {
            anim.SetTrigger("Ask");
            StartCoroutine(playAudio(canSeeFriends, () =>
            {
                currentParent.CantSeeFriends();
                anim.SetTrigger("Idle");
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