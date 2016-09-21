﻿using UnityEngine;

// Places the scrolling GameObject back at the bottom of the screen
// Used on the About Screen by the Credits
public class RestartScrolling : EndScrollAction
{
    public override void AfterScrollCompleted(Transform self, Vector3 originalPosition)
    {
        self.position = originalPosition - new Vector3(0f, self.parent.GetComponent<RectTransform>().rect.height, 0f);
    }
}
