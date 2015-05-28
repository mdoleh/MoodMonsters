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
        ShowIncorrectSymbol(true);
        sceneToLoad = sceneToLoadIncorrect;
    }

    public void TriggerCorrect(AudioSource audioSource, string sceneToLoadCorrect)
    {
        playAudio(audioSource);
        ShowCorrectSymbol(true);
        sceneToLoad = sceneToLoadCorrect;
    }

    public void ShowCorrectSymbol(bool show)
    {
        showSymbol(correctSymbol, correctSymbolAnimator, show);
    }

    public void ShowIncorrectSymbol(bool show)
    {
        showSymbol(noSymbol, noSymbolAnimator, show);
    }

    private void showSymbol(Canvas symbol, Animator animator, bool show)
    {
        symbol.enabled = show;
        if (show) animator.SetTrigger("ShowCanvas");
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
