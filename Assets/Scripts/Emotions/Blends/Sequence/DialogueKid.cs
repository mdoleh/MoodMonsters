using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

namespace BlendsScene
{
    // Used on the older child model to control his/her dialogue
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
            StartCoroutine(playAudio(canSeeFriends, () => anim.SetTrigger("Ask"), () =>
            {
                currentParent.CantSeeFriends();
                anim.SetTrigger("Idle");
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