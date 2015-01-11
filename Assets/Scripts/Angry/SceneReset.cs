using UnityEngine;
using System.Collections;

public class SceneReset : MonoBehaviour {
    public string sceneToLoadIncorrect;
    public string sceneToLoadCorrect;
    public Canvas noSymbol;
    public Canvas correctSymbol;
    AudioSource incorrectAudio;
    AudioSource correctAudio;
    bool startedPlaying = false;
    Animator noSymbolAnimator;
    Animator correctSymbolAnimator;
    string sceneToLoad;


    void Awake() {
        incorrectAudio = noSymbol.GetComponent<AudioSource>();
        noSymbolAnimator = noSymbol.GetComponent<Animator>();
        correctAudio = correctSymbol.GetComponent<AudioSource>();
        correctSymbolAnimator = correctSymbol.GetComponent<Animator>();
    }

    public void TriggerSceneReset()
    {
        incorrectAudio.Play();
        startedPlaying = true;
        noSymbol.enabled = true;
        noSymbolAnimator.SetTrigger("ShowCanvas");
        sceneToLoad = sceneToLoadIncorrect;
    }

    public void TriggerCorrect() {
        correctAudio.Play();
        startedPlaying = true;
        correctSymbol.enabled = true;
        correctSymbolAnimator.SetTrigger("ShowCanvas");
        sceneToLoad = sceneToLoadCorrect;
    }

    void Update() {
        if (startedPlaying && !incorrectAudio.isPlaying && !correctAudio.isPlaying) Utilities.LoadScene(sceneToLoad);
    }
}
