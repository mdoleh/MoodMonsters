using UnityEngine;

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

        public override void InitializeGameObjects()
        {
            base.InitializeGameObjects();
            scarlet = GameObject.Find("Scarlet").GetComponent<SkeeballCharacterMovement>();
        }
    }
}