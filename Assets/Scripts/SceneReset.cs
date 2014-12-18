using UnityEngine;
using System.Collections;

public class SceneReset : MonoBehaviour {
    public string sceneToLoad;
    public Canvas noSymbol;
    AudioSource audio;
    bool startedPlaying = false;
    Animator noSymbolAnimator;

    void Awake() {
        audio = GetComponent<AudioSource>();
        noSymbolAnimator = noSymbol.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Lily") {
            audio.Play();
            startedPlaying = true;
            noSymbol.enabled = true;
            noSymbolAnimator.SetTrigger("NotRight");
        }
    }

    void Update() {
        if (startedPlaying && !audio.isPlaying) Application.LoadLevel(sceneToLoad);
    }
}
