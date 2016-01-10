using UnityEngine;
using System.Collections;
using System.Linq;

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
        yield return StartCoroutine(playEmotions());
    }

    private IEnumerator playEmotions()
    {
        foreach (var emotion in emotions)
        {
            emotion.gameObject.SetActive(true);
            Utilities.PlayAudio(emotion);
            yield return new WaitForSeconds(emotion.clip.length);
        }
    }
}
