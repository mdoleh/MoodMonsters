using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WebCamPhotoCamera : MonoBehaviour
{
    private WebCamTexture webCamTexture;
    private IList<WebCamDevice> webCamDevices;
    public TakenImage takenPhotoTexture2D;
    public AudioSource pictureCountDownAudio;
    public AudioSource cameraShutterAudio;
    public AudioSource keepPictureAudio;
    public CameraActions cameraActions;
    public GameObject[] buttonsToDisable;
    public GameObject[] buttonsToEnable;

    void Start()
    {
        webCamDevices = WebCamTexture.devices;
        TurnOnCamera();
    }

    void Update()
    {
        if (webCamTexture != null)
        {
            GetComponent<RawImage>().texture = webCamTexture;
            if (!webCamTexture.videoVerticallyMirrored) 
                GetComponent<RawImage>().transform.localScale = new Vector3(-1, 1);
        }
    }

    public void TurnOnCamera()
    {
        webCamTexture = new WebCamTexture();
        var lastDevice = WebCamTexture.devices[WebCamTexture.devices.Length - 1].name;
        webCamTexture.deviceName = lastDevice;
        webCamTexture.Play();
    }

    public void CycleToNextDevice()
    {
        webCamTexture.Stop();
        var currentIndex = webCamDevices.IndexOf(webCamDevices.First(x => x.name.Equals(webCamTexture.deviceName)));
        ++currentIndex;
        if (currentIndex >= webCamDevices.Count)
        {
            currentIndex = 0;
        }
        webCamTexture.deviceName = webCamDevices[currentIndex].name;
        webCamTexture.Play();
    }

    public void TurnOffCamera()
    {
        webCamTexture.Stop();
    }

    public void TakePhoto()
    {
        if (!webCamTexture.isPlaying) TurnOnCamera();
        Utilities.StopAudio(Sound.CurrentPlayingSound);
        setInteractable(buttonsToEnable, false);
        StopAllCoroutines();
        StartCoroutine(StartTakingPhoto());
    }

    private IEnumerator StartTakingPhoto()
    {
        cameraActions.RunPrePictureActions();
        Utilities.PlayAudio(pictureCountDownAudio);
        yield return new WaitForSeconds(pictureCountDownAudio.clip.length + 0.5f);
        Utilities.PlayAudio(cameraShutterAudio);

        Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
        photo.SetPixels(webCamTexture.GetPixels());
        photo.Apply();

        if (takenPhotoTexture2D != null) takenPhotoTexture2D.TakenPicture = photo;
        
        showYesNoButtons();
        TurnOffCamera();
        GetComponent<RawImage>().texture = photo;
        Utilities.PlayAudio(keepPictureAudio);
    }

    public void KeepPhoto()
    {
        StopAllCoroutines();
        Utilities.StopAudio(Sound.CurrentPlayingSound);
        setAllButtons(buttonsToEnable, false);
        cameraActions.RunPostPictureActions();
    }

    private void setAllButtons(GameObject[] buttons, bool setActive)
    {
        foreach (var button in buttons)
        {
            button.SetActive(setActive);
        }
    }

    private void setInteractable(GameObject[] buttons, bool interactable)
    {
        foreach (var button in buttons)
        {
            button.GetComponent<Button>().interactable = interactable;
        }
    }

    private void showYesNoButtons()
    {
        setAllButtons(buttonsToDisable, false);
        setAllButtons(buttonsToEnable, true);
        setInteractable(buttonsToEnable, true);
    }
}
