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
    public CameraActions cameraActions;

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
        var currentIndex = webCamDevices.IndexOf(webCamDevices.First(x => x.name.Equals(webCamTexture.deviceName)));
        ++currentIndex;
        if (currentIndex >= webCamDevices.Count)
        {
            currentIndex = 0;
        }
        webCamTexture.deviceName = webCamDevices[currentIndex].name;
    }

    public void TurnOffCamera()
    {
        webCamTexture.Stop();
    }

    public void TakePhoto()
    {
        StopAllCoroutines();
        StartCoroutine(StartTakingPhoto());
    }

    private IEnumerator StartTakingPhoto()
    {
        cameraActions.RunPrePictureActions();
        Utilities.PlayAudio(pictureCountDownAudio);
        yield return new WaitForSeconds(pictureCountDownAudio.clip.length);
        Utilities.PlayAudio(cameraShutterAudio);

        Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
        photo.SetPixels(webCamTexture.GetPixels());
        photo.Apply();

        if (takenPhotoTexture2D != null) takenPhotoTexture2D.TakenPicture = photo;
        cameraActions.RunPostPictureActions();
    }
}
