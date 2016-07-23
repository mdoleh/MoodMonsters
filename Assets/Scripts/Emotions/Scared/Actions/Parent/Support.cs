using UnityEngine;

namespace ScaredScene
{
    public class Support : DefaultActionBase
    {
        public GameObject PASSLetter;

        protected override void DialogueAnimation()
        {
            anim.SetFloat("TalkSpeed", 3.767f / dialogue.clip.length);
            anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            anim.SetFloat("TalkSpeed", 1.0f);
            anim.SetTrigger("Idle");
            GUIHelper.NextGUI();
        }

        protected override void BeforeExplanation()
        {
            base.BeforeExplanation();
            PASSLetter.SetActive(true);
            PASSLetter.GetComponent<Animator>().SetTrigger("BlowUp");
        }

        protected override void BeforeAdditionalExplanation()
        {
            base.BeforeAdditionalExplanation();
            PASSLetter.GetComponent<Animator>().SetTrigger("Empty");
        }
    }
}