using System.Collections;
using Globals;
using UnityEngine;

public class PassTablet : MonoBehaviour
{
    public GameObject childToParentImage;
    public GameObject parentToChildImage;
    public AudioSource switchToParentAudio;
    public AudioSource switchToChildAudio;
    public AudioSource touchWhenReadyAudio;
    public GameObject arrows;

    private IEnumerator playInstructions(AudioSource audioToPlay)
    {
        yield return new 
            WaitForSeconds(Sound.CurrentPlayingSound.clip.length - Sound.CurrentPlayingSound.time);
        Utilities.PlayAudio(audioToPlay);
        yield return new WaitForSeconds(audioToPlay.clip.length);
        arrows.SetActive(true);
        Utilities.PlayAudio(touchWhenReadyAudio);
        Timeout.SetRepeatAudio(touchWhenReadyAudio);
        Timeout.StartTimers();
    }
    
    public void ImageClicked()
    {
        StopAllCoroutines();
        GUIHelper.NextGUI(GUIHelper.GetCurrentGUI(), GUIHelper.GetNextGUI());
        arrows.SetActive(false);
        childToParentImage.GetComponent<Animator>().SetTrigger("Normal");
        parentToChildImage.GetComponent<Animator>().SetTrigger("Normal");
        childToParentImage.SetActive(false);
        parentToChildImage.SetActive(false);
    }

    public void SwitchToParent()
    {
        if (GameFlags.AdultIsPresent)
        {
            childToParentImage.SetActive(true);
            StartCoroutine(playInstructions(switchToParentAudio));
        }
        else
        {
            GUIHelper.NextGUI();
        }
    }

    public void SwitchToChild()
    {
        if (GameFlags.AdultIsPresent)
        {
            parentToChildImage.SetActive(true);
            StartCoroutine(playInstructions(switchToChildAudio));
        }
        else
        {
            GUIHelper.NextGUI();
        }
    }
}
