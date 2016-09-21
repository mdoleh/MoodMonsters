using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Globals;
using UnityEngine;

// Handles the retaking of a photo if the player chooses to do so
public class RetakePhoto : MonoBehaviour
{
    public WebCamPhotoCamera webCam;
    private AudioSource makeAFaceInstruction;

	void Start () {
        var emotionInstructions = transform.parent.FindChild("Audio")
            .FindChild("Emotions")
            .GetComponentsInChildren<AudioSource>().ToList();
        makeAFaceInstruction = emotionInstructions.First(
                x => Scenes.GetLastEmotionCompleted().ToLower().Contains(x.gameObject.name.ToLower()));
	}

    public void RetakePicture()
    {
        Timeout.StopTimers();
        StartCoroutine(playMakeAFaceInstruction());
    }

    private IEnumerator playMakeAFaceInstruction()
    {
        Utilities.PlayAudio(makeAFaceInstruction);
        yield return new WaitForSeconds(makeAFaceInstruction.clip.length);
        webCam.TakePhoto();
    }
}
