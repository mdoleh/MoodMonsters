using UnityEngine;

public class LaneBasedMovementHandler : MonoBehaviour
{
    public int currentIndex = 1;
    public Transform[] lanes;
    private bool shouldAdjustPosition = true;

    public Vector3 AdjustPosition(Transform transform, Joystick joystick)
    {
        if (joystick.CurrentSpeedAndDirection.x == 0f) shouldAdjustPosition = true;
        if (!shouldAdjustPosition) return transform.position;
        Vector3 newPosition = transform.position;
        if (joystick.CurrentSpeedAndDirection.x <= -1.0f)
        {
            newPosition = currentIndex == 0 ? lanes[currentIndex].position : lanes[--currentIndex].position;
            shouldAdjustPosition = false;
        }
        else if (joystick.CurrentSpeedAndDirection.x >= 1.0f)
        {
            newPosition = currentIndex == lanes.Length - 1
                ? lanes[currentIndex].position
                : lanes[++currentIndex].position;
            shouldAdjustPosition = false;
        }
        return newPosition;
    }
}
