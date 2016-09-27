using UnityEngine;

namespace HappyScene
{
    // Custom behavior to handle on the scene starts after the tutorial plays
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