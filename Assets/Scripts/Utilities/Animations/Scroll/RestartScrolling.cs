using UnityEngine;

public class RestartScrolling : EndScrollAction
{
    public override void AfterScrollCompleted(Transform self, Vector3 originalPosition)
    {
        self.position = originalPosition - new Vector3(0f, self.parent.GetComponent<RectTransform>().rect.height, 0f);
    }
}
