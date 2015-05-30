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

    void Awake() {
        if (noSymbol != null) noSymbolAnimator = noSymbol.GetComponent<Animator>();
        if (correctSymbol != null) correctSymbolAnimator = correctSymbol.GetComponent<Animator>();
    }

    public void TriggerSceneReset(AudioSource audioSource, bool showSymbol)
    {
        StartCoroutine(DelayLoadingScene(audioSource, sceneToLoadIncorrect, showSymbol));
    }

    public void TriggerCorrect(AudioSource audioSource, string sceneToLoadCorrect, bool showSymbol)
    {
        StartCoroutine(DelayLoadingScene(audioSource, sceneToLoadCorrect, showSymbol));
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

    private IEnumerator DelayLoadingScene(AudioSource audioSource, string sceneToLoad, bool showSymbol)
    {
        Utilities.PlayAudio(audioSource);
        ShowCorrectSymbol(showSymbol);
        if (audioSource != null) yield return new WaitForSeconds(audioSource.clip.length);
        Timeout.StopTimers();
        Utilities.LoadScene(sceneToLoad);
    }
}
