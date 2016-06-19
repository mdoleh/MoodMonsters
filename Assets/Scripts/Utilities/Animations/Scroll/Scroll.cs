using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour
{
    public float startDelay = 3;
    public float speed = 1f;
    public Transform lastItem;
    public EndScrollAction scrollAction;

    private bool shouldScroll;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(delayScroll());
    }

    private IEnumerator delayScroll()
    {
        yield return new WaitForSeconds(startDelay);
        shouldScroll = true;
    }

    private void Update()
    {
        if (shouldScroll) transform.position += new Vector3(0f, 1f * speed, 0f);
        if (lastItem == null) return;
        if (lastItem.position.y > transform.GetComponent<RectTransform>().rect.height + lastItem.GetComponent<RectTransform>().rect.height)
            scrollAction.AfterScrollCompleted(transform, originalPosition);
    }
}
