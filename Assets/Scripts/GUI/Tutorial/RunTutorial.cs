using UnityEngine;
using System.Collections;
using UnityEditor;

public class RunTutorial : MonoBehaviour
{
    private AudioSource sceneAudio;
    private AudioSource buttonPushAudio;
//    private AudioSource helpAudio;
//    private AudioSource quitAudio;
//    private AudioSource repeatAudio;

    private GameObject practiceDropContainer;
    private GameObject practiceButton;
    private GameObject buttonPush;
    private GameObject initCanvas;
//    private GameObject helpCanvas;
//    private Color originalColor;

    private bool initialAudioPlayed = false;
//    private bool explainingHelpButton = false;
//    private bool explainingQuitButton = false;
//    private bool explainingRepeatButton = false;

    public void Initialize()
    {
        sceneAudio = GUIDetect.GetNextGUI(GUIDetect.GetCurrentGUIName()).GetComponent<AudioSource>();
        Utilities.PlayAudio(sceneAudio);
        initialAudioPlayed = true;

        InitializeGameObjects();
        InitializeAudio();
    }

    private void Update()
    {
        if (initialAudioPlayed && !sceneAudio.isPlaying) EnablePracticeUI();
    }

    private void InitializeGameObjects()
    {
        practiceDropContainer = transform.Find("DropContainer").gameObject;
        practiceButton = transform.Find("PracticeButton").gameObject;
        buttonPush = transform.Find("ButtonPush").gameObject;
        initCanvas = GameObject.Find("InitCanvas");
    }

    private void InitializeAudio()
    {
        buttonPushAudio = transform.Find("ButtonPush").gameObject.GetComponent<AudioSource>();
    }

    private void EnablePracticeUI()
    {
        initialAudioPlayed = false;
        practiceDropContainer.SetActive(true);
        practiceButton.SetActive(true);
        buttonPush.SetActive(true);
        initCanvas.SetActive(false);
        Utilities.PlayAudio(buttonPushAudio);
    }
}
