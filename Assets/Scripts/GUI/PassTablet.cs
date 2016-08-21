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

    private static PassTablet Instance;

    private void Start()
    {
        Instance = this;
    }

    private static IEnumerator playInstructions(AudioSource audioToPlay)
    {
        yield return new 
            WaitForSeconds(Sound.CurrentPlayingSound.clip.length - Sound.CurrentPlayingSound.time);
        Utilities.PlayAudio(audioToPlay);
        yield return new WaitForSeconds(audioToPlay.clip.length);
        Instance.arrows.SetActive(true);
        Utilities.PlayAudio(Instance.touchWhenReadyAudio);
        Timeout.SetRepeatAudio(Instance.touchWhenReadyAudio);
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

    public static bool HasInstance()
    {
        return Instance != null;
    }

    public static void SwitchToParent()
    {
        Instance.childToParentImage.SetActive(true);
        Instance.StartCoroutine(playInstructions(Instance.switchToParentAudio));
    }

    public static void SwitchToChild()
    {
        Instance.parentToChildImage.SetActive(true);
        Instance.StartCoroutine(playInstructions(Instance.switchToChildAudio));
    }
}
