using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

public class GetReadyForMove : ActionBase
{
    public Animator[] siblings;
    public AudioSource dialogue;

    private Animator sibling;

    private void Start()
    {
        sibling = siblings.ToList().Find(x => x.transform.parent.name.Equals(GameFlags.PlayerGender));
    }

    public override void StartAction()
    {
        base.StartAction();
        StartCoroutine(Explain());
    }

    private IEnumerator Explain()
    {
        sibling.SetTrigger("Idle");
        anim.SetTrigger("Talking");
        Utilities.PlayAudio(dialogue);
        yield return new WaitForSeconds(dialogue.clip.length);
        anim.SetTrigger("Idle");
        sceneReset.TriggerCorrect(actionExplanation, "EndScreen", true);
    }
}
