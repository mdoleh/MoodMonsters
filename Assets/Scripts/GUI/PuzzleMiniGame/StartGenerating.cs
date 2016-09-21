using EndScreen;
using Globals;
using PuzzleMiniGame;
using UnityEngine;
using UnityEngine.UI;

// Custom actions for the webcam that trigger
// the puzzle to start generating
public class StartGenerating : CameraActions
{
    public WebCamPhotoCamera webCam;
    public CreatePuzzleGrid gridGenerator;

    public override void RunPostPictureActions()
    {
        webCam.TurnOffCamera();
        webCam.gameObject.SetActive(false);
        gridGenerator.StartGeneratingGrid();
        gameObject.SetActive(false);
    }

    public override void RunPrePictureActions()
    {
        Timeout.StopTimers();
        GetComponent<Button>().interactable = false;
    }
}
