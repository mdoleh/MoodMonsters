using PuzzleMiniGame;
using UnityEngine;
using UnityEngine.UI;

public class StartGenerating : CameraActions
{
    public WebCamPhotoCamera webCam;
    public CreatePuzzleGrid gridGenerator;
    public GameObject changeDeviceButton;

    public override void RunPostPictureActions()
    {
        webCam.TurnOffCamera();
        webCam.gameObject.SetActive(false);
        changeDeviceButton.SetActive(false);
        gridGenerator.StartGeneratingGrid();
        gameObject.SetActive(false);
    }

    public override void RunPrePictureActions()
    {
        GetComponent<Button>().interactable = false;
    }
}
