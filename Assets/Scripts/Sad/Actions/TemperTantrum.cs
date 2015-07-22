using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class TemperTantrum : ActionBase
    {
        public AudioSource notFairAudio;

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
            anim.SetTrigger("Tantrum");
            StartCoroutine(PlayTantrumAudio());
        }

        private IEnumerator PlayTantrumAudio()
        {
            Utilities.PlayAudio(notFairAudio);
            yield return new WaitForSeconds(notFairAudio.clip.length);
            TriggerIncorrect();
        }
    }
}