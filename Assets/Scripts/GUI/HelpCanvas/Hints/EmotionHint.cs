using System.Linq;
using Globals;
using UnityEngine;

public class EmotionHint : SimpleHint
{
    public Transform mainCamera;
    public Vector3 zoomPosition;
    public Vector3 zoomRotation;

    [Header("Optional")]
    public ShowEmotion[] characters;
    public string emotionToShow;
    public string afterEmotionToShow;

    private Vector3 originalPosition = Vector3.zero;
    private Vector3 originalRotation = Vector3.zero;
    private ShowEmotion character;

    private void Start()
    {
        if (characters != null)
            character = characters.ToList().Find(x => x.gameObject.name.Contains(GameFlags.PlayerGender));
    }

    public void ShowHint(bool playAudio = true)
    {
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
        if (character != null) character.AfterAnimation(afterEmotionToShow);
        mainCamera.position = originalPosition;
        mainCamera.rotation = Quaternion.Euler(originalRotation);
    }
}
