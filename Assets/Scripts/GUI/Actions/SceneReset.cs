using UnityEngine;
using System.Collections;

public class SceneReset : MonoBehaviour {
    public string sceneToLoadIncorrect;
    public string sceneToLoadCorrect;
    public Canvas noSymbol;
    public Canvas correctSymbol;
    bool startedPlaying = false;
    Animator noSymbolAnimator;
    Animator correctSymbolAnimator;
    private AudioSource source;
    string sceneToLoad;


    void Awake() {
        noSymbolAnimator = noSymbol.GetComponent<Animator>();
        correctSymbolAnimator = correctSymbol.GetComponent<Animator>();
    }

    public void TriggerSceneReset(AudioSource audioSource)
    {
        playAudio(audioSource);
        noSymbol.enabled = true;
        noSymbolAnimator.SetTrigger("ShowCanvas");
        sceneToLoad = sceneToLoadIncorrect;
    }

    public void TriggerCorrect(AudioSource audioSource) {
        playAudio(audioSource);
        correctSymbol.enabled = true;
        correctSymbolAnimator.SetTrigger("ShowCanvas");
        sceneToLoad = sceneToLoadCorrect;
    }

    private void playAudio(AudioSource audioSource)
    {
        source = audioSource;
        Utilities.PlayAudio(audioSource);
        startedPlaying = true;
    }

    void Update() {
        if (startedPlaying && source != null && !source.isPlaying) Utilities.LoadScene(sceneToLoad);
    }
}
