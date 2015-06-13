using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;
using UnityEditor;

public class TakePhoto : MonoBehaviour
{
    public AudioSource getFaceIntoOvalAudio;
    public AudioSource pictureCountDownAudio;
    public AudioSource[] emotionInstructions;

	void Start ()
	{
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
    }
}
