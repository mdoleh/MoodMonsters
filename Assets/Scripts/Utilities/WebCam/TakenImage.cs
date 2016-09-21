using UnityEngine;

// Stores an image taken by the WebCam
// Texture2Ds are lost once presented on the screen
// to preserve the type, save it here
public class TakenImage : MonoBehaviour
{
    public Texture2D Image;
}
