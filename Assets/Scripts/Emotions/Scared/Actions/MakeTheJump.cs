using System.Collections;
using ScaredScene;
using UnityEngine;

namespace ScaredScene
{
    // Incorrect option choice for both Emotion and Situation Actions
    public class MakeTheJump : ActionBase
    {
        public override void StartAction()
        {
            base.StartAction();
            ShowCorrect(true);
            StartCoroutine(Explain());
        }

        private IEnumerator Explain()
        {
            Utilities.PlayAudio(actionExplanation);
            yield return new WaitForSeconds(actionExplanation.clip.length);
            ShowCorrect(false);
            gameObject.GetComponent<ExplainFear>().StartJumpSequence();
        }
    }
}