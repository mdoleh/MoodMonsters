using System;
using UnityEngine;

public class SoccerMovementHandler : MovementHandler
{
    public LaneBasedMovementHandler laneBasedMovementHandler;

    public override void HandleMovement(Joystick joystick)
    {
        float moveSpeed = Time.deltaTime * joystick.CurrentSpeedAndDirection.y;
        transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
        var newPositionZ = laneBasedMovementHandler.AdjustPosition(transform, joystick).z;
        transform.position = new Vector3(transform.position.x, transform.position.y, newPositionZ);
        restrictMovement(joystick);
    }

    private void restrictMovement(Joystick joystickScript)
    {
        var controller = gameObject.GetComponent<ControllerMovement>();
        if (joystickScript.CurrentSpeedAndDirection.y > 0) controller.StartRunningAnimation();
        // limit character's position so it can't move behind the camera
        if (Math.Abs(controller.mainCamera.transform.position.x - transform.position.x) < 1.0f)
        {
            transform.position = new Vector3(controller.mainCamera.transform.position.x + 1.0f, transform.position.y, transform.position.z);
        }
    }
}
