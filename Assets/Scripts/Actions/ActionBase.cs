using UnityEngine;
using System.Collections;
using Globals;

public class ActionBase : MonoBehaviour
{
    protected bool startTimer = false;
    protected bool eventTrigger = false;
    protected bool isCorrect = false;
    protected float timer = 0.0f;
    public SceneReset sceneReset;
    public AudioSource audioSource;
    bool sceneResetting = false;

    protected virtual void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
        }

        if (eventTrigger && timer > 5.0f && !sceneResetting)
        {
            if (isCorrect) {
                sceneReset.TriggerCorrect(audioSource, Scenes.GetNextMiniGame());
            } else {
                sceneReset.TriggerSceneReset(audioSource);
            }
            sceneResetting = true;
        }
    }

    public virtual void StartAction()
    {
        Timeout.StopTimers();
    }

    protected void TriggerCorrect()
    {
        sceneReset.TriggerCorrect(audioSource, Scenes.GetNextMiniGame());
    }

    protected void TriggerIncorrect()
    {
        sceneReset.TriggerSceneReset(audioSource);
    }

    protected void ShowCorrect(bool show)
    {
        sceneReset.ShowCorrectSymbol(show);
    }

    protected void ShowIncorrect(bool show)
    {
        sceneReset.ShowIncorrectSymbol(show);
    }
}