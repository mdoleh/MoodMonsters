using System.Collections;
using System.Collections.Generic;
using Globals;
using UnityEngine;
using UnityEngine.UI;
using CharacterMovement = ScaredScene.CharacterMovement;

namespace ScaredScene
{
    public class ScaredTutorial : TutorialBase
    {
        public GameObject scarlet;
        public GameObject aj;

        protected override void HelpExplanationComplete()
        {
            base.HelpExplanationComplete();
            GUIInitialization.Initialize();

            scarlet.GetComponent<CharacterMovement>().StartSequence();
            aj.GetComponent<CharacterMovement>().StartSequence();
        }
    }
}