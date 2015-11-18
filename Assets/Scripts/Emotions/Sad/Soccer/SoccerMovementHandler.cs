using System.Collections;
using System.Linq;
using SadScene;
using UnityEngine;

public class SoccerMovementHandler : MovementHandler
{
    public Transform[] lanes;
    private int currentIndex = 1;
    private bool shouldAdjustPosition = true;

    public override void HandleMovement(Transform transform, Joystick joystick)
    {
        float moveSpeed = Time.deltaTime * joystick.CurrentSpeedAndDirection.y;
        transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
        StartCoroutine(adjustPosition(transform, joystick));
    }

    private IEnumerator adjustPosition(Transform transform, Joystick joystick)
    {
        if (!shouldAdjustPosition) yield break;
        shouldAdjustPosition = false;
        yield return new WaitForSeconds(0.5f);
        float newPositionZ = transform.position.z;
        if (joystick.CurrentSpeedAndDirection.x < -0.5f)
        {
            newPositionZ = currentIndex == 0 ? lanes[currentIndex].position.z : lanes[--currentIndex].position.z;
        }
        else if (joystick.CurrentSpeedAndDirection.x > 0.5f)
        {
            newPositionZ = currentIndex == lanes.Length - 1 ? lanes[currentIndex].position.z : lanes[++currentIndex].position.z;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, newPositionZ);
        shouldAdjustPosition = true;
    }
}
