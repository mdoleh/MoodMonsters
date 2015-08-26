using UnityEngine;
using System.Collections;

public class WrongAnswer : ButtonDragDrop
{
    private AudioSource[] wrongAudio;
    private Animator coinAnimator;

    protected override void Awake()
    {
        base.Awake();
        coinAnimator = GameObject.Find("ScoreCanvas").transform.FindChild("CoinAnimation").GetComponent<Animator>();
        wrongAudio = transform.parent.Find("WrongAnswerAudio").GetComponentsInChildren<AudioSource>();
    }

    public override void ButtonDown()
    {
        base.ButtonDown();
        Debug.Log("Wrong answer clicked");
    }

    public override void SubmitAnswer()
    {
        DecrementCorrectCount();
        base.SubmitAnswer();
        Debug.Log("Wrong answer submitted");
        showCoinAnimation();
        Utilities.PlayRandomAudio(wrongAudio);
    }

    private void showCoinAnimation()
    {
        coinAnimator.gameObject.SetActive(true);
        coinAnimator.SetTrigger("Remove");
    }
}
