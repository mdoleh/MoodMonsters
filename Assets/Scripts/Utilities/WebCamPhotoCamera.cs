using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WebCamPhotoCamera : MonoBehaviour
{
    WebCamTexture webCamTexture;
    public RawImage takenRawImage;
    public TakenImage takenPhotoTexture2D;
    public AudioSource pictureCountDownAudio;
    public AudioSource cameraShutterAudio;
    public CameraActions cameraActions;

    void Start()
    {
        webCamTexture = new WebCamTexture();
        webCamTexture.Play();
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
        webCamTexture.Play();
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

        if (takenRawImage != null) takenRawImage.texture = photo;
        if (takenPhotoTexture2D != null) takenPhotoTexture2D.TakenPicture = photo;
        cameraActions.RunPostPictureActions();
    }
}
