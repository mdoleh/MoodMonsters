using UnityEngine;
using System.Collections;

// Used by non-action answers that are incorrect
// resets the canvas to its previous state on submit
// and triggers and audio clip
public class WrongAnswer : ButtonDragDrop
{
    private AudioSource[] wrongAudio;
    private Coin coin;

    protected override void Awake()
    {
        base.Awake();
        coin = GameObject.Find("ScoreCanvas").transform.FindChild("CoinAnimation").GetComponent<Coin>();
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
        coin.ShowRemoveCoinAnimation();
        StartCoroutine(playAudio());
    }

    private IEnumerator playAudio()
    {
        var audioPlaying = Utilities.PlayRandomAudio(wrongAudio);
        yield return new WaitForSeconds(audioPlaying.clip.length);
        var emotionHint = GUIHelper.GetCurrentGUI().GetComponent<EmotionHint>();
        if (emotionHint != null) emotionHint.ShowHint();
    }
}
