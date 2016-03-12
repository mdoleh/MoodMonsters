using System.Linq;
using UnityEngine;

public class PhysicalHint : SimpleHint
{
    public Animator anim;
    public string animationTrigger;
    public string animationResetTrigger;

    public override void ShowHint()
    {
        base.ShowHint();
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(animationTrigger))
            anim.SetTrigger(animationTrigger);
    }

    public override void NotifyCanvasChange()
    {
        anim.SetTrigger(animationResetTrigger);
    }
}
