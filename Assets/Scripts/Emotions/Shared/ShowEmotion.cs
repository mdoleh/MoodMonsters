using UnityEngine;

// Used by EmotionHints to show and reset character animations
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
        if (anim.GetCurrentAnimatorStateInfo(1).IsName(trigger)) return;
        anim.SetTrigger(trigger);
    }

    public void AfterAnimation(string trigger)
    {
        anim.SetTrigger(trigger);
    }
}
