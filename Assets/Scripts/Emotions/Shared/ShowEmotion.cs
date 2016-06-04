using UnityEngine;

public class ShowEmotion : MonoBehaviour
{
    [Header("Optional")]
    public Animator anim;

    private void Start()
    {
        if (anim == null) anim = GetComponent<Animator>();
    }

    public void ShowAnimation(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    public void AfterAnimation(string trigger)
    {
        anim.SetTrigger(trigger);
    }
}
