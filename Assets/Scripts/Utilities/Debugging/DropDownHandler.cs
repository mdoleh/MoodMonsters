using UnityEngine;
using System.Collections;

public class DropDownHandler : MonoBehaviour
{
    public void HideDropDownList()
    {
        var canvasGroup = transform.Find("Dropdown List").GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void EnableDropDownList()
    {
        var canvasGroup = transform.Find("Dropdown List").GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}
