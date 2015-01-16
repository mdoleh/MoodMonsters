using UnityEngine;
using System.Collections;

namespace HelpGUI
{
    public class RepeatButton : HelpBase
    {
        private bool initialInstructionsPlayed = false;

        private AudioSource initialAudio;
        private AudioSource additionalAudio;

        protected override void DoubleClickAction()
        {
            instructions.Stop();
            var currentCanvas = GUIDetect.GetCurrentGUI();
            initialAudio = currentCanvas.GetComponent<AudioSource>();
            Utilities.PlayAudio(initialAudio);
            initialInstructionsPlayed = true;

            var additionalGameObject = currentCanvas.transform.Find("AdditionalInstructions");
            if (additionalGameObject == null) return;
            additionalAudio = additionalGameObject.GetComponent<AudioSource>();
        }

        protected override void Update()
        {
            if (initialInstructionsPlayed && !initialAudio.isPlaying)
            {
                initialInstructionsPlayed = false;
                Utilities.PlayAudio(additionalAudio);
            }
        }
    }
}