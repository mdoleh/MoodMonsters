using System.Linq;
using UnityEngine;

public class PhysicalHint : HintBase
{
    public AudioSource hintToPlay;
    public Animator anim;
    public string animationTrigger;
    public string animationResetTrigger;

    public override void ShowHint()
    {
        Utilities.PlayAudio(hintToPlay);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(animationTrigger))
            anim.SetTrigger(animationTrigger);
    }

    public override void NotifyCanvasChange()
    {
        anim.SetTrigger(animationResetTrigger);
    }
}
