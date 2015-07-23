using UnityEngine;
using System.Collections;

public class ConveySadness : ActionBase
{
    public AudioSource expressSadDialogue;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public override void StartAction()
    {
        base.StartAction();
        ShowCorrect(true);
        StartCoroutine(Explain());
    }

    private IEnumerator Explain()
    {
        Utilities.PlayAudio(actionExplanation);
        yield return new WaitForSeconds(actionExplanation.clip.length);
        ShowCorrect(false);
        anim.SetTrigger("Talk");
        Utilities.PlayAudio(expressSadDialogue);
        yield return new WaitForSeconds(expressSadDialogue.clip.length);
        GameObject.Find("EmotionActionsCanvas").GetComponent<Canvas>().enabled = true;
        GUIDetect.NextGUI();
    }
}
