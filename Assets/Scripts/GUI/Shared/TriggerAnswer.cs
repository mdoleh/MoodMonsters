using System.Linq;
using UnityEngine;

// Used by non-action answers that trigger an animation\
// TODO: this may no longer be needed
public class TriggerAnswer : CorrectAnswer
{
    public Animator[] characters;

    public override void SubmitAnswer()
    {
        base.SubmitAnswer();
        characters.ToList().ForEach(x =>
        {
            if (x.gameObject.activeInHierarchy)
                x.SetTrigger(gameObject.name);
        });
    }
}
