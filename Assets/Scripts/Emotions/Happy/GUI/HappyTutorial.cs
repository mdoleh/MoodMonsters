using UnityEngine;
using System.Collections;

namespace HappyScene
{
    public class HappyTutorial : TutorialBase
    {
        private SkeeballCharacterMovement scarlet;
        private AudioSource helpScarlet;

        protected override void HelpExplanationComplete()
        {
            base.HelpExplanationComplete();
            StartCoroutine(giveObjective());
        }

        private IEnumerator giveObjective()
        {
            Utilities.PlayAudio(helpScarlet);
            yield return new WaitForSeconds(helpScarlet.clip.length);
            scarlet.StartSequence();
        }

        protected override void InitializeAudio()
        {
            base.InitializeAudio();
            helpScarlet = transform.FindChild("HelpScarlet").GetComponent<AudioSource>();
            scarlet = GameObject.Find("Scarlet").GetComponent<SkeeballCharacterMovement>();
        }
    }
}