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
    public AudioSource actionExplanation;
    bool sceneResetting = false;

    public virtual void StartAction()
    {
        Timeout.StopTimers();
    }

    protected void TriggerCorrect()
    {
        sceneReset.TriggerCorrect(actionExplanation, Scenes.GetNextMiniGame(), true);
    }

    protected void TriggerIncorrect()
    {
        sceneReset.TriggerSceneReset(actionExplanation, true);
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