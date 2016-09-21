using UnityEngine;
using System.Collections;

// Customizable behavior for what happens after the End Credits finish scrolling
public abstract class EndScrollAction : MonoBehaviour
{
    public abstract void AfterScrollCompleted(Transform self, Vector3 originalPosition);
}
