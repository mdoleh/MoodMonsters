using System.Linq;
using UnityEngine;

// Plays an animation on a character to show body language
// corresponding to one of the answer choices on the screen
// also plays an audio clip
public class PhysicalHint : SimpleHint
{
    public Animator[] anims;
    public string animationTrigger;
    public string animationResetTrigger;

    public override void ShowHint()
    {
        base.ShowHint();
        if (!anims.ToList().TrueForAll(x => x.GetCurrentAnimatorStateInfo(1).IsName(animationTrigger)))
            anims.ToList().ForEach(x => x.SetTrigger(animationTrigger));
    }

    public override void NotifyCanvasChange()
    {
        if (anims.ToList().TrueForAll(x => x.GetCurrentAnimatorStateInfo(1).IsName(animationTrigger)))
            anims.ToList().ForEach(x => x.SetTrigger(animationResetTrigger));
    }
}
