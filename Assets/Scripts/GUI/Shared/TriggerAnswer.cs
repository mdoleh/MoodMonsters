using System.Linq;
using UnityEngine;

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
