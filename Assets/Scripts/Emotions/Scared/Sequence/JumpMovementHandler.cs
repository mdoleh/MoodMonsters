using System;
using System.Collections;
using UnityEngine;

namespace ScaredScene
{
    // Used on AJ to control the player interactions to make him move accordingly
    public class JumpMovementHandler : MovementHandler
    {
        public float minZ = 166.84f;
        public float maxZ = 167.4674f;

        public override void HandleMovement(Joystick joystick)
        {
            float moveSpeed = Time.deltaTime*joystick.CurrentSpeedAndDirection.y;
            float moveDirection = Time.deltaTime*joystick.CurrentSpeedAndDirection.x;
            transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y,
                transform.position.z - moveDirection);
            restrictMovement(joystick);
        }

        private void restrictMovement(Joystick joystickScript)
        {
            var controller = gameObject.GetComponent<ControllerMovement>();
            if (joystickScript.CurrentSpeedAndDirection.y > 0) controller.StartRunningAnimation();
            // limit character's position laterally (z-direction)
            if (transform.position.z <= minZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
            }
            else if (transform.position.z >= maxZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
            }
            // limit character's position so it can't move behind the camera
            if (Math.Abs(controller.mainCamera.transform.position.x - transform.position.x) < 1.0f)
            {
                transform.position = new Vector3(controller.mainCamera.transform.position.x + 1.0f, transform.position.y,
                    transform.position.z);
            }
        }
    }
}