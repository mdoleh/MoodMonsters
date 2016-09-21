using UnityEngine;

// Can be overridden to provide custom behaviors
// when the webcam is about to take a photo
public abstract class CameraActions : MonoBehaviour
{
    public abstract void RunPostPictureActions();
    public abstract void RunPrePictureActions();
}
