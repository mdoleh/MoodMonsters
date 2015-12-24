using System;
using System.Collections;
using UnityEngine;

public class JumpMovementHandler : MovementHandler
{
    public override void HandleMovement(Joystick joystick)
    {
        float moveSpeed = Time.deltaTime * joystick.CurrentSpeedAndDirection.y;
        float moveDirection = Time.deltaTime * joystick.CurrentSpeedAndDirection.x;
        transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z - moveDirection);
        restrictMovement(joystick);
    }

    private void restrictMovement(Joystick joystickScript)
    {
        var controller = gameObject.GetComponent<ControllerMovement>();
        if (joystickScript.CurrentSpeedAndDirection.y > 0) controller.StartRunningAnimation();
        // limit character's position laterally (z-direction)
        if (transform.position.z > controller.zMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, controller.zMax);
        }
        else if (transform.position.z < controller.zMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, controller.zMin);
        }
        // limit character's position so it can't move behind the camera
        if (Math.Abs(controller.mainCamera.transform.position.x - transform.position.x) < 1.0f)
        {
            transform.position = new Vector3(controller.mainCamera.transform.position.x + 1.0f, transform.position.y, transform.position.z);
        }
    }
}
