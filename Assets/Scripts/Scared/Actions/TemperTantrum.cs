using UnityEngine;
using System.Collections;

namespace ScaredScene
{
    public class TemperTantrum : ActionBase
    {
        public AudioSource tantrumDialogue;
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public override void StartAction()
        {
            base.StartAction();
            StartTantrum();
        }

        private void StartTantrum()
        {
            transform.Find("CameraFollow").gameObject.SetActive(false);
            anim.SetTrigger("Tantrum");
            StartCoroutine(ResetScene());
        }

        private IEnumerator ResetScene()
        {
            Utilities.PlayAudio(tantrumDialogue);
            yield return new WaitForSeconds(tantrumDialogue.clip.length);
            sceneReset.TriggerSceneReset(actionExplanation, true);
        }
    }
}