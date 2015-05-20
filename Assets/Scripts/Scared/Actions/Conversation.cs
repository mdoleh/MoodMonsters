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
    }

    public void StartJumpSequence()
    {
        other.gameObject.GetComponent<ExplainFear>().StartJumpSequence();
    }
}
