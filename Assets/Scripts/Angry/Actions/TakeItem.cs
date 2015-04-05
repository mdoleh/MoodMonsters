﻿using UnityEngine;
using System.Collections;
using Globals;

namespace AngryScene
{
    public class TakeItem : MonoBehaviour
    {
        public string lastGUI;
        private GameObject ipadCamera;
        private GameObject miniGame;
        private Animator anim;
        public Animator other;

        public void Awake()
        {
            ipadCamera = GameObject.Find("iPadCamera");
            miniGame = GameObject.Find("MiniGame");
            anim = GetComponent<Animator>();
        }

        public void Start()
        {
            StartCoroutine(DelayAnimation());
        }

        private IEnumerator DelayAnimation()
        {
            yield return new WaitForSeconds(1f);
            anim.SetTrigger("IsTalking");
        }

        public void TakeIPad()
        {
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

        public void MoveIpad()
        {
            var ipad = GameObject.Find("iPad");
            var hand = GameObject.Find("Boy:RightHand");
            ipad.transform.parent = hand.transform;
            ipad.transform.localPosition = new Vector3(0.16965f, -0.18118f, 0.20516f);
            ipad.transform.localRotation = Quaternion.Euler(0.5527962f, 278.4825f, 301.6339f);
        }

        public void ShiftToLeftHand()
        {
            var ipad = GameObject.Find("iPad");
            var hand = GameObject.Find("Boy:LeftHand");
            ipad.transform.parent = hand.transform;
            ipad.transform.localPosition = new Vector3(-0.15317f, -0.17448f, 0.1441f);
            ipad.transform.localRotation = Quaternion.Euler(334.0472f, 53.15136f, 93.76542f);
        }

        void StartGUI()
        {
            Timeout.StartTimers();
            GUIDetect.NextGUI(lastGUI, GUIDetect.GetNextGUIName(lastGUI));
            enabled = false;
        }
    }
}