﻿using System.Linq;
using Globals;
using UnityEngine;

namespace BlendsScene
{
    public class Support : DefaultActionBase
    {
        public GameObject PASSLetter;
        public GameObject[] PASSLetters;

        protected override void DialogueAnimation()
        {
            anim.SetTrigger("Talk");
            anim.speed = anim.GetCurrentAnimatorClipInfo(0).Length/dialogue.clip.length;
            PASSLetters.ToList().ForEach(x => x.SetActive(false));
        }

        protected override void AfterDialogue()
        {
            anim.speed = 1f;
            anim.SetTrigger("Idle");
            if (!GameFlags.AdultIsPresent)
            {
                GetComponent<AskToSolve>().StartDefaultAction();
                return;
            }
            GUIHelper.NextGUI();
        }

        protected override void BeforeExplanation()
        {
            base.BeforeExplanation();
            if (!GameFlags.AdultIsPresent) return;
            PASSLetter.SetActive(true);
            PASSLetter.GetComponent<Animator>().SetTrigger("BlowUp");
        }

        protected override void BeforeAdditionalExplanation()
        {
            base.BeforeAdditionalExplanation();
            if (!GameFlags.AdultIsPresent) return;
            PASSLetter.GetComponent<Animator>().SetTrigger("Empty");
        }
    }
}