using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

namespace SadScene
{
    public class Ask : DefaultActionBase
    {
        public OutsideGroupDialogue child;
        public AudioSource theyWontLetMePlay;
        public GameObject[] PASSLetters;

        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            PASSLetters.ToList().First(x => x.name.ToLower().Equals("a")).GetComponent<Animator>().SetTrigger("Empty");
//            anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            base.AfterDialogue();
//            anim.SetTrigger("Idle");
            sceneReset.sceneToLoadIncorrect = "SadSceneSmallCitySituationActionsMenu";
            StartCoroutine(NextGUI());
        }

        protected override void BeforeExplanation()
        {
            base.BeforeExplanation();
            PASSLetters.ToList().ForEach(x => x.SetActive(true));
            PASSLetters.ToList().First(x => x.name.ToLower().Equals("p")).GetComponent<Animator>().SetTrigger("BlowUp");
        }

        protected override void BeforeAdditionalExplanation()
        {
            base.BeforeAdditionalExplanation();
            PASSLetters.ToList().First(x => x.name.ToLower().Equals("p")).GetComponent<Animator>().SetTrigger("Empty");
            PASSLetters.ToList().First(x => x.name.ToLower().Equals("a")).GetComponent<Animator>().SetTrigger("BlowUp");
        }

        private IEnumerator NextGUI()
        {
            yield return child.PlayDialogue(theyWontLetMePlay);
            child.TriggerIdleAnimation();
            var currentCanvas = GUIHelper.GetCurrentGUI();
            if (currentCanvas == null || !currentCanvas.name.ToLower().Contains("default"))
            {
                // something different
                yield return new WaitForSeconds(0f);
            }
            GUIHelper.GetPreviousGUI("ParentSupportCanvas" + GameFlags.ParentGender).enabled = true;
            GUIHelper.NextGUI();
        }
    }
}