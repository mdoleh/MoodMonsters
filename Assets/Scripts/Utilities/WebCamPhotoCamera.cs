using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WebCamPhotoCamera : MonoBehaviour
{
    WebCamTexture webCamTexture;
    public RawImage takenRawImage;
    public TakenImage takenPhotoTexture2D;

    void Start()
    {
        webCamTexture = new WebCamTexture();
        webCamTexture.Play();
    }

    void Update()
    {
        GetComponent<RawImage>().texture = webCamTexture;
    }

    public void TakePhoto()
    {
        Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
        photo.SetPixels(webCamTexture.GetPixels());
        photo.Apply();

        if (takenRawImage != null) takenRawImage.texture = photo;
        if (takenPhotoTexture2D != null) takenPhotoTexture2D.TakenPicture = photo;
    }
}
