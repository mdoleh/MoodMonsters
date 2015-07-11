using System.Collections;
using System.Collections.Generic;
using AngryScene;
using Globals;
using UnityEngine;
using UnityEngine.UI;

public class AngryTutorial : TutorialBase
{
    private AudioSource helpLilyPlayAudio;
    private AudioSource whatLilyIsPlayingAudio;

    public GameObject otherCharacter;
    private GameObject fingerDrag;
    private GameObject ipadCamera;
    public GameObject miniGame;
    private GameObject ipadCameraFrame;

    protected override void HelpExplanationComplete()
    {
        base.HelpExplanationComplete();
        GUIDetect.CanvasList = new List<string>
        {
            "TutorialCanvas", "EmotionsCanvas", "PhysicalCanvas1", "PhysicalCanvas2", "PhysicalCanvas3", "ActionsCanvas"
        };
        StartCoroutine(HelpLilyPlayAudio());
    }

    private IEnumerator HelpLilyPlayAudio()
    {
        ipadCamera.GetComponent<Camera>().enabled = true;
        ipadCameraFrame.GetComponent<Image>().enabled = true;
        miniGame.SetActive(true);
        Utilities.PlayAudio(whatLilyIsPlayingAudio);
        yield return new WaitForSeconds(whatLilyIsPlayingAudio.clip.length);

        Utilities.PlayAudio(helpLilyPlayAudio);
        fingerDrag.SetActive(true);
        yield return new WaitForSeconds(helpLilyPlayAudio.clip.length);
        fingerDrag.SetActive(false);
        otherCharacter.SetActive(true);
        otherCharacter.GetComponent<WalkForward>().StartWalking();
    }

    public override void InitializeGameObjects()
    {
        base.InitializeGameObjects();
        fingerDrag = transform.Find("FingerDrag").gameObject;
        ipadCamera = GameObject.Find("iPadCamera");
        ipadCameraFrame = GameObject.Find("iPadCameraFrame");
    }

    protected override void InitializeAudio()
    {
        base.InitializeAudio();
        helpLilyPlayAudio = transform.Find("HelpLilyPlay").gameObject.GetComponent<AudioSource>();
        whatLilyIsPlayingAudio = transform.Find("WhatLilyIsPlaying").gameObject.GetComponent<AudioSource>();
    }
}