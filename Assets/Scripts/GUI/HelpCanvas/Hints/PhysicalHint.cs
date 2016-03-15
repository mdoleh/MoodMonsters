using System.Linq;
using UnityEngine;

public class PhysicalHint : SimpleHint
{
    public Animator[] anims;
    public string animationTrigger;
    public string animationResetTrigger;

    public override void ShowHint()
    {
        base.ShowHint();
        if (!anims.ToList().TrueForAll(x => x.GetCurrentAnimatorStateInfo(0).IsName(animationTrigger)))
            anims.ToList().ForEach(x => x.SetTrigger(animationTrigger));
    }

    public override void NotifyCanvasChange()
    {
        if (anims.ToList().TrueForAll(x => x.GetCurrentAnimatorStateInfo(0).IsName(animationTrigger)))
            anims.ToList().ForEach(x => x.SetTrigger(animationResetTrigger));
    }
}
