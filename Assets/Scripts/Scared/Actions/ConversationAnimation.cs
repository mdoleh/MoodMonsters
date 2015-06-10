using UnityEngine;
using System.Collections;
using ScaredScene;

public class ConversationAnimation : MonoBehaviour
{
    public Animator anim;
    public Animator other;

    public void StartListening()
    {
        anim.SetTrigger("Listening");
        other.SetTrigger("Talking");
    }
}
