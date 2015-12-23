using UnityEngine;
using System.Collections;

namespace HappyScene
{
    public class HappyTutorial : TutorialBase
    {
        private SkeeballCharacterMovement scarlet;

        protected override void HelpExplanationComplete()
        {
            base.HelpExplanationComplete();
            scarlet.StartSequence();
        }

        protected override void InitializeAudio()
        {
            base.InitializeAudio();
            scarlet = GameObject.Find("Scarlet").GetComponent<SkeeballCharacterMovement>();
        }
    }
}