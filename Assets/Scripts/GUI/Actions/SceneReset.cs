using UnityEngine;
using System.Collections;
using Globals;

public class SceneReset : MonoBehaviour {
    public string sceneToLoadIncorrect;
    public Canvas noSymbol;
    public Canvas correctSymbol;
    bool startedPlaying = false;
    Animator noSymbolAnimator;
    Animator correctSymbolAnimator;
    private AudioSource source;
    string sceneToLoad;


    void Awake() {
        if (noSymbol != null) noSymbolAnimator = noSymbol.GetComponent<Animator>();
        if (correctSymbol != null) correctSymbolAnimator = correctSymbol.GetComponent<Animator>();
    }

    public void TriggerSceneReset(AudioSource audioSource)
    {
        playAudio(audioSource);
        noSymbol.enabled = true;
        noSymbolAnimator.SetTrigger("ShowCanvas");
        sceneToLoad = sceneToLoadIncorrect;
    }

    public void TriggerCorrect(AudioSource audioSource, string sceneToLoadCorrect)
    {
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
        if (startedPlaying && source != null && !source.isPlaying)
        {
            Timeout.StopTimers();
            Utilities.LoadScene(sceneToLoad);
        }
    }
}
