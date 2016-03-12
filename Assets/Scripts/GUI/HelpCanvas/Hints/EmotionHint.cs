using UnityEngine;

public class EmotionHint : SimpleHint
{
    public Transform mainCamera;
    public Vector3 zoomPosition;
    public Vector3 zoomRotation;
    private Vector3 originalPosition;
    private Vector3 originalRotation;

    public void ShowHint(bool playAudio = true)
    {
        if (playAudio) base.ShowHint();
        originalPosition = mainCamera.position;
        originalRotation = mainCamera.rotation.eulerAngles;
        mainCamera.position = zoomPosition;
        mainCamera.rotation = Quaternion.Euler(zoomRotation);
    }

    public override void NotifyCanvasChange()
    {
        mainCamera.position = originalPosition;
        mainCamera.rotation = Quaternion.Euler(originalRotation);
    }
}
