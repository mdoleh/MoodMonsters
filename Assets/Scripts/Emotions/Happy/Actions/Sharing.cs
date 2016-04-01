using UnityEngine;
using System.Collections;
using System.Linq;
using HappyScene;

public class Sharing : ActionBase
{
    public AutomatedFollowPlayer otherCharacter;
    public AudioSource dialogue;

    public override void StartAction()
    {
        base.StartAction();
        StartCoroutine(sharePrize());
    }

    private IEnumerator sharePrize()
    {
        anim.SetTrigger("Give");
        otherCharacter.TakePrize();
        Utilities.PlayAudio(dialogue);
        yield return new WaitForSeconds(dialogue.clip.length);
        TriggerCorrect();
    }
}
