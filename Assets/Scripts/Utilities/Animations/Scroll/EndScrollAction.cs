using UnityEngine;
using System.Collections;

public abstract class EndScrollAction : MonoBehaviour
{
    public abstract void AfterScrollCompleted(Transform self, Vector3 originalPosition);
}
