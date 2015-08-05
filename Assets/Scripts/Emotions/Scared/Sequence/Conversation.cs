using UnityEngine;
using System.Collections;
using ScaredScene;

public class Conversation : MonoBehaviour
{
    public Animator anim;
    public Animator other;

    public AudioSource encourageDialogue;
    public AudioSource comfortDialogue;
    public AudioSource successDialogue;
    public AudioSource explanationAudio;

    private bool accoladeTriggered = false;

    public void GiveEncouragement()
    {
        anim.SetTrigger("Talking");
        Utilities.PlayAudio(encourageDialogue);
    }

    public void GiveComfort()
    {
        anim.SetBool("IsIdle", false);
        anim.SetTrigger("Talking");
        Utilities.PlayAudio(comfortDialogue);
    }

    public void GiveAccolade()
    {
        anim.SetBool("IsIdle", false);
        if (accoladeTriggered) return;
        accoladeTriggered = true;
        Utilities.PlayAudio(successDialogue);
        StartCoroutine(PlayExplanation());
    }

    public void ClappingAnimation()
    {
        accoladeTriggered = true;
        anim.SetBool("IsIdle", false);
        anim.SetTrigger("Clap");
    }

    private IEnumerator PlayExplanation()
    {
        yield return new WaitForSeconds(successDialogue.clip.length);
        Utilities.PlayAudio(explanationAudio);
        yield return new WaitForSeconds(explanationAudio.clip.length);
        other.gameObject.GetComponent<ExplainFear>().GoToMiniGame();
    }

    public void AfraidToFall()
    {
        anim.SetBool("IsIdle", true);
        other.gameObject.GetComponent<ExplainFear>().AfraidToFall();
    }

    public void StartJumpSequence()
    {
        anim.SetBool("IsIdle", true);
        other.gameObject.GetComponent<ExplainFear>().StartJumpSequence();
    }
}
