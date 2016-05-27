using System.Linq;
using Globals;
using UnityEngine;

public class GenderSpecificHint : HintBase
{
    public AudioSource[] hints;

    public override void ShowHint()
    {
        var hintToPlay = hints.ToList().Find(x => x.gameObject.name.ToLower().Equals(GameFlags.PlayerGender.ToLower()));
        Utilities.PlayAudio(hintToPlay);
    }

    public override void NotifyCanvasChange()
    {

    }
}