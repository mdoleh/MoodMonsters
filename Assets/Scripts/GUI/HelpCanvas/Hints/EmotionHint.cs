using System.Linq;
using Globals;
using UnityEngine;

// Moves the camera to focus on the characters faces
// to show their expressions and plays an audio clip
public class EmotionHint : SimpleHint
{
    public Transform mainCamera;
    public Vector3 zoomPosition;
    public Vector3 zoomRotation;
    public bool returnCameraToOriginalPosition = true;

    [Header("Optional")]
    public ShowEmotion[] characters;
    public string emotionToShow;
    public string afterEmotionToShow;

    private static Vector3 originalPosition = Vector3.zero;
    private static Vector3 originalRotation = Vector3.zero;
    private ShowEmotion character;

    private void initializeCharacter()
    {
        if (characters != null && character == null)
            character =
                characters.ToList().Find(x => x.transform.parent.name.ToLower().Equals(GameFlags.PlayerGender.ToLower()));
    }

    public void ShowHint(bool playAudio = true)
    {
        initializeCharacter();
        if (playAudio) base.ShowHint();
        if (originalPosition == Vector3.zero)
        {
            originalPosition = mainCamera.position;
            originalRotation = mainCamera.rotation.eulerAngles;
        }
        if (character != null) character.ShowAnimation(emotionToShow);
        mainCamera.position = zoomPosition;
        mainCamera.rotation = Quaternion.Euler(zoomRotation);
    }

    public override void NotifyCanvasChange()
    {
        initializeCharacter();
        if (character != null) character.AfterAnimation(afterEmotionToShow);
        if (!returnCameraToOriginalPosition) return;
        mainCamera.position = originalPosition;
        mainCamera.rotation = Quaternion.Euler(originalRotation);
        originalPosition = Vector3.zero;
        originalRotation = Vector3.zero;
    }
}
