﻿using UnityEngine;
using System.Collections;
using Globals;
using UnityEngine.UI;

namespace AngryScene
{
    public class TakeItem : MonoBehaviour
    {
        private GameObject dialogue;
        private GameObject ipadCamera;
        private GameObject miniGame;
        protected Animator anim;
        public Animator other;
        private GameObject ipadCameraFrame;

        public void Awake()
        {
            dialogue = transform.FindChild("Dialogue").gameObject;
            ipadCamera = GameObject.Find("iPadCamera");
            ipadCameraFrame = GameObject.Find("iPadCameraFrame");
            miniGame = GameObject.Find("MiniGame");
            anim = GetComponent<Animator>();
        }

        public IEnumerator StartTalking()
        {
            yield return new WaitForSeconds(1f);
            anim.SetTrigger("IsTalking");
            var letMePlay = dialogue.transform.FindChild("LetMePlay").GetComponent<AudioSource>();
            Utilities.PlayAudio(letMePlay);
            yield return new WaitForSeconds(letMePlay.clip.length);
        }

        public void TriggerFootStamp()
        {
            anim.SetTrigger("IsTalking");
            StartCoroutine(PlayComeOnDialogue());
        }

        private IEnumerator PlayComeOnDialogue()
        {
            yield return new WaitForSeconds(1.5f);
            var comeOn = dialogue.transform.FindChild("ComeOn").GetComponent<AudioSource>();
            Utilities.PlayAudio(comeOn);
        }

        public void TakeIPad()
        {
            ipadCameraFrame.GetComponent<Image>().enabled = false;
            ipadCamera.SetActive(false);
            miniGame.SetActive(false);

            anim.SetTrigger("IsTakingIPad");
            other.SetBool("IsUsingIPad", false);
            other.SetTrigger("IsLosingIPad");
            StartCoroutine(DelayGUI());
        }

        private IEnumerator DelayGUI()
        {
            yield return new WaitForSeconds(1f);
            StartGUI();
        }

        public void StartUsingIPad() {
            anim.SetBool("IsUsingIPad", true);
            other.SetTrigger("IsAngry");
        }

        public virtual void MoveIpad()
        {
            var ipad = GameObject.Find("iPad");
            var arm = GameObject.Find("Boy:RightHand").transform.parent.gameObject;
            ipad.transform.parent = arm.transform.FindChild("mixamorig:RightHand");
            ipad.transform.localPosition = new Vector3(-0.133f, 0.094f, 0.085f);
            ipad.transform.localRotation = Quaternion.Euler(90f, 235.7971f, 0f);
        }

        public virtual void ShiftToLeftHand()
        {
            var ipad = GameObject.Find("iPad");
            var arm = GameObject.Find("Boy:LeftHand").transform.parent.gameObject;
            ipad.transform.parent = arm.transform.FindChild("mixamorig:LeftHand");
            ipad.transform.localPosition = new Vector3(0.093f, 0.137f, 0.136f);
            ipad.transform.localRotation = Quaternion.Euler(66.94399f, 118.2474f, 34.07929f);
        }

        void StartGUI()
        {
            GUIDetect.NextGUI();
            GetComponent<WalkForward>().tutorial.EnableHelpGUI();
            enabled = false;
        }
    }
}