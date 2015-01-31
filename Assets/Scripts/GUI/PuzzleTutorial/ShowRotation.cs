using UnityEngine;
using System.Collections;

namespace PuzzleTutorial
{
    public class ShowRotation : TutorialAction
    {
        public ObjectBase practiceTool;

        public override void DoAction()
        {
            FeedbackManager.Instance.Setup(practiceTool, FeedbackManager.TargetState.rotating);
            StartCoroutine(PositionPracticeObject());
        }

        private IEnumerator PositionPracticeObject()
        {
            yield return new WaitForSeconds(audio.clip.length);
            FeedbackManager.Instance.Disable(0.2f);
            practiceTool.transform.rotation = Quaternion.Euler(0f, 0f, 17.24014f);
            GetComponent<Animator>().enabled = false;
        }
    }
}