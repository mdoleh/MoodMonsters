using UnityEngine;

// Simple class placed on 2 characters in a scene
// to get them talking to each other alternating who talks and listens
// StartListening() should be triggered by an animation event in both
// characters to get them to alternate
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