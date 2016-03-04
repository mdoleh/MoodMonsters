using UnityEngine;

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
