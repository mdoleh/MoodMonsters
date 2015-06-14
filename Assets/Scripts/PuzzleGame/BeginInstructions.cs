using System.Collections;
using System.Linq;
using Globals;
using UnityEngine;

public class BeginInstructions : MonoBehaviour
{
    public AudioSource getFaceIntoOvalAudio;
    public AudioSource pictureCountDownAudio;
    public AudioSource leftButtonAudio;
    public AudioSource rightButtonAudio;
    public AudioSource[] emotionInstructions;
    public GameObject disablePanel;
    public GameObject rightButtonArrow;
    public GameObject leftButtonArrow;

	void Start ()
	{
	    if (Tutorials.CameraTutorialHasRun) return;
        StartCoroutine(playInstructions());
	}

    private IEnumerator playInstructions()
    {
        var makeFaceInstruction =
            emotionInstructions.First(
                x => Scenes.GetLastSceneCompleted().ToLower().Contains(x.gameObject.name.ToLower()));

        Utilities.PlayAudio(makeFaceInstruction);
        yield return new WaitForSeconds(makeFaceInstruction.clip.length);

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

        disablePanel.SetActive(false);
        Tutorials.CameraTutorialHasRun = true;
    }
}
