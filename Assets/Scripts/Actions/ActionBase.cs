using UnityEngine;
using System.Collections;
using Globals;

public class ActionBase : MonoBehaviour
{
    protected Animator anim;
    public SceneReset sceneReset;
    public AudioSource actionExplanation;
    private Coin coin;

    protected void Awake()
    {
        anim = GetComponent<Animator>();
        coin = GameObject.Find("ScoreCanvas").transform.FindChild("CoinAnimation").GetComponent<Coin>();
    }

    public virtual void StartAction()
    {
        Timeout.StopTimers();
    }

    protected void TriggerCorrect()
    {
        coin.ShowAddCoinAnimation();
        sceneReset.TriggerCorrect(actionExplanation, Scenes.GetNextMiniGame(), true);
    }

    protected void TriggerIncorrect()
    {
        coin.ShowRemoveCoinAnimation();
        sceneReset.TriggerSceneReset(actionExplanation, true);
    }

    protected void ShowCorrect(bool show)
    {
        coin.ShowAddCoinAnimation();
        sceneReset.ShowCorrectSymbol(show);
    }

    protected void ShowIncorrect(bool show)
    {
        coin.ShowRemoveCoinAnimation();
        sceneReset.ShowIncorrectSymbol(show);
    }
}