using System.Linq;
using Globals;
using UnityEngine;

// Used only by the Blends Scene
// Chooses a hint audio clip to play based
// on the player's gender
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