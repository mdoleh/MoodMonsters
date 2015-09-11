using System.Collections;
using System.Linq;
using Globals;
using UnityEngine;
using UnityEngine.UI;

public class BeginInstructions : MonoBehaviour
{
    public AudioSource getFaceIntoOvalAudio;
    public AudioSource pictureCountDownAudio;
    public AudioSource leftButtonAudio;
    public AudioSource rightButtonAudio;
    public GameObject disablePanel;
    public GameObject rightButtonArrow;
    public GameObject leftButtonArrow;
    public GameObject[] kidsFacesImages;
    
    [HideInInspector]
    public GameObject picturesToShow;

	void Start ()
	{
        Timeout.StopTimers();
        StartCoroutine(faceInstructions());
	}

    private IEnumerator faceInstructions()
    {
        yield return new WaitForSeconds(1.5f);

        var makingFacesAudioList = transform.FindChild("Audio")
            .FindChild("MakingFaces")
            .GetComponentsInChildren<AudioSource>().ToList();
        var makingFacesAudio = makingFacesAudioList.First(
            x => Scenes.GetLastSceneCompleted().ToLower().Contains(x.gameObject.name.ToLower()));
        Utilities.PlayAudio(makingFacesAudio);
        picturesToShow =
            kidsFacesImages.First(x => Scenes.GetLastSceneCompleted().ToLower().Contains(x.gameObject.name.ToLower()));
        picturesToShow.SetActive(true);
        yield return new WaitForSeconds(makingFacesAudio.clip.length);

        var emotionInstructions = transform.FindChild("Audio")
            .FindChild("Emotions")
            .GetComponentsInChildren<AudioSource>().ToList();
        var makeFaceInstruction =
            emotionInstructions.First(
                x => Scenes.GetLastSceneCompleted().ToLower().Contains(x.gameObject.name.ToLower()));

        Utilities.PlayAudio(makeFaceInstruction);
        yield return new WaitForSeconds(makeFaceInstruction.clip.length);
        yield return StartCoroutine(positionInstructions());
    }

    private IEnumerator positionInstructions()
    {
        if (!GameFlags.CameraTutorialHasRun)
        {
            Utilities.PlayAudio(getFaceIntoOvalAudio);
            yield return new WaitForSeconds(getFaceIntoOvalAudio.clip.length);

            Utilities.PlayAudio(rightButtonAudio);
            rightButtonArrow.SetActive(true);
            yield return new WaitForSeconds(rightButtonAudio.clip.length);
            rightButtonArrow.SetActive(false);

            leftButtonArrow.SetActive(true);
            Utilities.PlayAudio(leftButtonAudio);
            yield return new WaitForSeconds(leftButtonAudio.clip.length);
            leftButtonArrow.SetActive(false);
        }
        disablePanel.SetActive(false);
        GameFlags.CameraTutorialHasRun = true;
        Timeout.SetRepeatAudio(rightButtonAudio);
        Timeout.StartTimers();
    }
}
