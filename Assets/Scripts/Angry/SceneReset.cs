using UnityEngine;
using System.Collections;

public class SceneReset : MonoBehaviour {
    public string sceneToLoad;
    public Canvas noSymbol;
    AudioSource incorrectAudio;
    bool startedPlaying = false;
    Animator noSymbolAnimator;

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
    }

    public void TriggerCorrect() {
        Debug.Log("Correct!");
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
