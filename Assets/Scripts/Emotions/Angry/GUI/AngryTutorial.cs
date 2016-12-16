using System.Collections;
using UnityEngine;

namespace AngryScene
{
    // Controls how the scene starts after the tutorial plays
    public class AngryTutorial : TutorialBase
    {
        private AudioSource helpLilyPlayAudio;
        private AudioSource whatLilyIsPlayingAudio;

        public GameObject otherCharacter;
        public Animator lily;
        private GameObject fingerDrag;
        public GameObject ipadCamera;
        public GameObject miniGame;
        public GameObject ipadCanvas;
        private Transform ipadBucketTracker;
        public Transform bucket;
        private Transform maxX;
        private Transform minX;

        protected override void HelpExplanationComplete()
        {
            base.HelpExplanationComplete();
            StartCoroutine(HelpLilyPlayAudio());
        }

        private IEnumerator HelpLilyPlayAudio()
        {
            // activate the bucket game
            HideNoInputSymbol();
            lily.SetTrigger("Swipe");
            ipadCamera.SetActive(true);
            ipadCanvas.SetActive(true);
            miniGame.SetActive(true);
            Utilities.PlayAudio(whatLilyIsPlayingAudio);
            yield return new WaitForSeconds(whatLilyIsPlayingAudio.clip.length);

            // play the bucket game instructions
            Utilities.PlayAudio(helpLilyPlayAudio);
            fingerDrag.SetActive(true);
            yield return new WaitForSeconds(helpLilyPlayAudio.clip.length);
            fingerDrag.SetActive(false);

            // bring Ty into frame
            otherCharacter.SetActive(true);
            otherCharacter.GetComponent<WalkForward>().StartWalking();
        }

        public override void InitializeGameObjects()
        {
            base.InitializeGameObjects();
            fingerDrag = transform.Find("FingerDrag").gameObject;
            ipadBucketTracker = ipadCanvas.transform.FindChild("Circle");
            maxX = ipadCanvas.transform.FindChild("Max");
            minX = ipadCanvas.transform.FindChild("Min");
        }

        protected override void InitializeAudio()
        {
            base.InitializeAudio();
            helpLilyPlayAudio = transform.Find("HelpLilyPlay").gameObject.GetComponent<AudioSource>();
            whatLilyIsPlayingAudio = transform.Find("WhatLilyIsPlaying").gameObject.GetComponent<AudioSource>();
        }

        // keeps the yellow circle over the bucket in sync with the bucket itself
        private void Update()
        {
            var percentMoved = (bucket.position.x + 2.5f)/5.0f;
            var max = maxX.localPosition.x - (ipadBucketTracker.GetComponent<RectTransform>().rect.width/2.0f);
            var min = minX.localPosition.x + (ipadBucketTracker.GetComponent<RectTransform>().rect.width/2.0f);
            ipadBucketTracker.localPosition = new Vector2(min + ((max - min)*percentMoved),
                ipadBucketTracker.localPosition.y);
        }
    }
}