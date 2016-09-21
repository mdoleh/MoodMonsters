using System.Collections;
using UnityEngine;

// Plays an audio clip corresponding to
// PASS letters on the screen
// Also animates the PASS letters
public class ParentHint : HintBase
{
    public AudioSource[] hints;
    public Animator[] passLetters;

    public override void ShowHint()
    {
        StartCoroutine(playHint());
    }

    public override void NotifyCanvasChange()
    {
        
    }

    private IEnumerator playHint()
    {
        for (var i = 0; i < hints.Length; ++i)
        {
            Utilities.PlayAudio(hints[i]);
            passLetters[i].SetTrigger("BlowUp");
            yield return new WaitForSeconds(hints[i].clip.length);
            passLetters[i].SetTrigger("Empty");
        }
    }
}