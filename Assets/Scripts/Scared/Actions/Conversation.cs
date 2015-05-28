using UnityEngine;
using System.Collections;
using ScaredScene;

public class Conversation : MonoBehaviour
{
    public Animator anim;
    public Animator other;

    public void StartListening()
    {
        anim.SetTrigger("Listening");
        other.SetTrigger("Talking");
    }

    public void StartTalking()
    {
        anim.SetTrigger("Talking");
        Utilities.PlayAudio(GetComponent<AudioSource>());
    }

    public void StartJumpSequence()
    {
        anim.SetTrigger("Idle");
        other.gameObject.GetComponent<ExplainFear>().StartJumpSequence();
    }
}
