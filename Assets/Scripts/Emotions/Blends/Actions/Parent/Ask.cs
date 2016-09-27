using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

namespace BlendsScene
{
    // Correct option for ParentPayAttentionAsk
    public class Ask : DefaultActionBase
    {
        public GameObject[] PASSLetters;

        protected override void DialogueAnimation()
        {
            PASSLetters.ToList().First(x => x.name.ToLower().Equals("ask")).GetComponent<Animator>().SetTrigger("Empty");
            PASSLetters.ToList().ForEach(x => x.SetActive(false));
            anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            anim.SetTrigger("Idle");
            GUIHelper.NextGUI();
        }

        protected override void BeforeExplanation()
        {
            base.BeforeExplanation();
            if (!GameFlags.AdultIsPresent) return;
            PASSLetters.ToList().ForEach(x => x.SetActive(true));
            PASSLetters.ToList().First(x => x.name.ToLower().Equals("payattention")).GetComponent<Animator>().SetTrigger("BlowUp");
        }

        protected override void BeforeAdditionalExplanation()
        {
            base.BeforeAdditionalExplanation();
            if (!GameFlags.AdultIsPresent) return;
            PASSLetters.ToList().First(x => x.name.ToLower().Equals("payattention")).GetComponent<Animator>().SetTrigger("Empty");
            PASSLetters.ToList().First(x => x.name.ToLower().Equals("ask")).GetComponent<Animator>().SetTrigger("BlowUp");
        }
    }
}