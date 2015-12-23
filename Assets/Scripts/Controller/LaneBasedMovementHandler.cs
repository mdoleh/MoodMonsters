using UnityEngine;

public class LaneBasedMovementHandler : MonoBehaviour
{
    public int currentIndex = 1;
    public Transform[] lanes;
    private bool shouldAdjustPosition = true;

    public void AdjustPosition(Transform transform, Joystick joystick)
    {
        if (joystick.CurrentSpeedAndDirection.x == 0f) shouldAdjustPosition = true;
        if (!shouldAdjustPosition) return;
        float newPositionZ = transform.position.z;
        if (joystick.CurrentSpeedAndDirection.x <= -1.0f)
        {
            newPositionZ = currentIndex == 0 ? lanes[currentIndex].position.z : lanes[--currentIndex].position.z;
            shouldAdjustPosition = false;
        }
        else if (joystick.CurrentSpeedAndDirection.x >= 1.0f)
        {
            newPositionZ = currentIndex == lanes.Length - 1
                ? lanes[currentIndex].position.z
                : lanes[++currentIndex].position.z;
            shouldAdjustPosition = false;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, newPositionZ);
    }
}
