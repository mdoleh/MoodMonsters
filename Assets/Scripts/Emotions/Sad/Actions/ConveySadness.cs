using UnityEngine;
using System.Collections;
using Globals;
using UnityEngine.UI;

namespace SadScene
{
    public class ConveySadness : CorrectActionBase
    {
        public AudioSource switchToParentAudio;

        private GameObject childToParentImage;

        protected void Start()
        {
            childToParentImage = GameObject.Find("PassTabletCanvas").transform.FindChild("ChildToParent").gameObject;
        }

        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            base.AfterDialogue();
            anim.SetTrigger("Idle");
            sceneReset.sceneToLoadIncorrect = "SadSceneSmallCityParentPayAttentionAskActionsMenu";
            StartCoroutine(SwitchToParent());
        }

        private IEnumerator SwitchToParent()
        {
            if (GameFlags.AdultIsPresent)
            {
                childToParentImage.GetComponent<RawImage>().enabled = true;
                Utilities.PlayAudio(switchToParentAudio);
                yield return new WaitForSeconds(switchToParentAudio.clip.length);
                childToParentImage.GetComponent<RawImage>().enabled = false;
            }
            GUIHelper.NextGUI();
        }
    }
}