using UnityEngine;
using System.Collections;

public class Conversation : MonoBehaviour
{
    public Animator anim;
    public Animator other;

    public void StartListening()
    {
        anim.SetTrigger("Listening");
        other.SetTrigger("Talking");
    }
}
