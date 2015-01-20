using UnityEngine;
using System.Collections;

namespace PuzzleTutorial
{
    public class ShowTools : TutorialAction
    {
        public Transform tool;

        public override void DoAction()
        {
            ToolboxManager.Instance.ButtonPressed();
            transform.position = new Vector3(tool.position.x, tool.position.y + 1.5f);
            StartCoroutine(HideTools());
        }

        private IEnumerator HideTools()
        {
            yield return new WaitForSeconds(audio.clip.length);
            ToolboxManager.Instance.ButtonPressed();
        }
    }
}