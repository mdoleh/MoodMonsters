﻿using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using Globals;
using UnityEngine.UI;

namespace SadScene
{
    public class AskToSolve : DefaultActionBase
    {
        public AudioSource switchToChildAudio;
        public GameObject PASSLetter;
        public GameObject[] PASSLetters;

        private GameObject parentToChildImage;

        protected void Start()
        {
            parentToChildImage = GameObject.Find("PassTabletCanvas").transform.FindChild("ParentToChild").gameObject;
        }

        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            GameFlags.HasSeenPASS = true;
            PASSLetters.ToList().ForEach(x => x.SetActive(false));
//            anim.SetTrigger("Talk");
        }

        protected override void AfterDialogue()
        {
            base.AfterDialogue();
//            anim.SetTrigger("Idle");
            sceneReset.sceneToLoadIncorrect = "SadSceneSmallCitySituationActionsMenu";
            StartCoroutine(SwitchBackToChild());
        }

        private IEnumerator SwitchBackToChild()
        {
            if (GameFlags.AdultIsPresent)
            {
                parentToChildImage.GetComponent<RawImage>().enabled = true;
                Utilities.PlayAudio(switchToChildAudio);
                yield return new WaitForSeconds(switchToChildAudio.clip.length);
                parentToChildImage.GetComponent<RawImage>().enabled = false;
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

        protected override IEnumerator BeforeAdditionalExplanationCoroutine()
        {
            PASSLetter.GetComponent<Animator>().SetTrigger("Empty");
            if (!GameFlags.AdultIsPresent) yield break;
            var list = PASSLetters.ToList();
            foreach (var letter in list)
            {
                letter.GetComponent<Animator>().SetTrigger("BlowUp");
                var letterAudio = letter.GetComponent<AudioSource>();
                Utilities.PlayAudio(letterAudio);
                yield return new WaitForSeconds(letterAudio.clip.length);
            }
            yield return base.BeforeAdditionalExplanationCoroutine();
        }
    }
}