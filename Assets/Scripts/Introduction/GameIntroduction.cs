using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

public class GameIntroduction : MonoBehaviour
{
    public BasicCameraMovements mainCamera;

    [Header("Kids' Audio")]
    // Kids' audio
    public AudioSource bodyAndFace;
    public AudioSource useWordsLike;
    public AudioSource[] emotions;

    [Header("Adults' Audio")]
    // Adults' audio
    public AudioSource PASSIntro;
    public AudioSource[] PASSLetters;

    private void Start()
    {
        StartCoroutine(playIntro());
    }

    private IEnumerator playIntro()
    {
        yield return new WaitForSeconds(2f);
        mainCamera.PanRight((position) => position.x <= 204.352f);
        Utilities.PlayAudio(bodyAndFace);
        yield return new WaitForSeconds(bodyAndFace.clip.length);
        Utilities.PlayAudio(useWordsLike);
        yield return new WaitForSeconds(useWordsLike.clip.length);
        yield return StartCoroutine(playListOfAudio(emotions));
        hideListOfObjects(emotions);
        yield return StartCoroutine(playParentSection());
        Utilities.LoadScene("MainMenuScreen");
    }

    private IEnumerator playListOfAudio(AudioSource[] audioList)
    {
        foreach (var audio in audioList)
        {
            audio.gameObject.SetActive(true);
            Utilities.PlayAudio(audio);
            yield return new WaitForSeconds(audio.clip.length);
        }
    }

    private void hideListOfObjects(AudioSource[] audioList)
    {
        audioList.ToList().ForEach(element => element.gameObject.SetActive(false));
    }

    private IEnumerator playParentSection()
    {
        if (!GameFlags.AdultIsPresent) yield break;
        Utilities.PlayAudio(PASSIntro);
        yield return new WaitForSeconds(PASSIntro.clip.length);
        yield return StartCoroutine(playListOfAudio(PASSLetters));
    }
}
