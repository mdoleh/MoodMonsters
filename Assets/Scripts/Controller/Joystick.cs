using UnityEngine;
using System.Collections;
using Globals;

public class Joystick : MonoBehaviour
{
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    private Vector3 originalPosition;
    private bool initialized = false;

	private void Initialize() 
    {
        var parent = transform.parent.GetComponent<RectTransform>().rect;
        xMin = transform.TransformPoint(new Vector3(parent.xMin, 0f, 0f)).x;
        xMax = transform.TransformPoint(new Vector3(parent.xMax, 0f, 0f)).x;
        yMin = transform.TransformPoint(new Vector3(0f, parent.yMin, 0f)).y;
        yMax = transform.TransformPoint(new Vector3(0f, parent.yMax, 0f)).y;
	    initialized = true;
    }

    public virtual void ButtonDown()
    {
        if (!initialized) Initialize();
        originalPosition = transform.position;
        Timeout.StopTimers();
        StopAllCoroutines();
    }

    public virtual void ButtonRelease()
    {
        transform.position = originalPosition;
    }

    public void Drag()
    {
        if (isInRange(transform.position) && isInRange(Input.mousePosition))
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else if (isInRangeX(transform.position) && isInRangeX(Input.mousePosition))
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y > yMax ? yMax : yMin);
        }
        else if (isInRangeY(transform.position) && isInRangeY(Input.mousePosition))
        {
            transform.position = new Vector2(Input.mousePosition.x > xMax ? xMax : xMin, Input.mousePosition.y);
        }
    }

    private bool isInRange(Vector3 position)
    {
        return isInRangeX(position) && isInRangeY(position);
    }

    private bool isInRangeX(Vector3 position)
    {
        return position.x >= xMin && position.x <= xMax;
    }

    private bool isInRangeY(Vector3 position)
    {
        return position.y >= yMin && position.y <= yMax;
    }
}
