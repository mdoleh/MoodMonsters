using UnityEngine;

public class DraggingHorizontally : MonoBehaviour
{
    public Transform dragging;
    public Transform target;

    public bool moveTargetWithDragging = false;

    public float speed;
    // this is speedSmallScreen / (screenWidth / speedSmallScreen)
    // test on small screen first, determine desired speed, then 
    // compute constant using above
    public float constant;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = dragging.localPosition;
    }

    private void Update()
    {
        dragging.localPosition = new Vector3(dragging.localPosition.x + Time.deltaTime * (Screen.width / speed) * constant,
                dragging.localPosition.y);
        if (dragging.localPosition.x >= target.localPosition.x / 2.0f)
        {
            dragging.localPosition = initialPosition;
        }

        if (moveTargetWithDragging) target.localPosition = new Vector2(dragging.localPosition.x, target.localPosition.y);
    }
}
