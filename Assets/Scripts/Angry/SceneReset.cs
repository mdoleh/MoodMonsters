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
        incorrectAudio = GetComponent<AudioSource>();
        noSymbolAnimator = noSymbol.GetComponent<Animator>();
    }

    public void TriggerSceneReset()
    {
        incorrectAudio.Play();
        startedPlaying = true;
        noSymbol.enabled = true;
        noSymbolAnimator.SetTrigger("NotRight");
        sceneToLoad = sceneToLoadIncorrect;
    }

    public void TriggerCorrect() {
        correctAudio.Play();
        startedPlaying = true;
        correctSymbol.enabled = true;
        correctSymbolAnimator.SetTrigger("Right");
        sceneToLoad = sceneToLoadCorrect;
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == "Lily") {
    //        audio.Play();
    //        startedPlaying = true;
    //        noSymbol.enabled = true;
    //        noSymbolAnimator.SetTrigger("NotRight");
    //    }
    //}

    void Update() {
        if (startedPlaying && !audio.isPlaying) Application.LoadLevel(sceneToLoad);
    }
}
