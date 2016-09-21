using UnityEngine;

// Plays a simple audio clip to provide a hint to the player
// Usually placed on Canvases directly
public class SimpleHint : HintBase
{
    public AudioSource hintToPlay;

    public override void ShowHint()
    {
        Utilities.PlayAudio(hintToPlay);
    }

    public override void NotifyCanvasChange()
    {
        
    }
}
