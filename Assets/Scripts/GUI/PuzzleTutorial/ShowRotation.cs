using UnityEngine;
using System.Collections;

namespace PuzzleTutorial
{
    public class ShowRotation : TutorialAction
    {
        public ObjectBase practiceTool;

        public override void DoAction()
        {
            practiceTool.gameObject.SetActive(true);
            FeedbackManager.Instance.Setup(practiceTool, FeedbackManager.TargetState.rotating);
            StartCoroutine(DestroyPracticeObject());
        }

        private IEnumerator DestroyPracticeObject()
        {
            yield return new WaitForSeconds(audio.clip.length);
            FeedbackManager.Instance.Disable(0.2f);
            Destroy(practiceTool.gameObject);
        }
    }
}