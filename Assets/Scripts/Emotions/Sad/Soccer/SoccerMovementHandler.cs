using System;
using SadScene;
using UnityEngine;

namespace SadScene
{
// Used by Sad Scene to move Luis in fixed lanes in the left & right directions
    public class SoccerMovementHandler : MovementHandler
    {
        public LaneBasedMovementHandler laneBasedMovementHandler;
        private float moveSpeed = 0f;

        public override void HandleMovement(Joystick joystick)
        {
            if (joystick.CurrentSpeedAndDirection.y >= 2.0f)
            {
                moveSpeed = Time.deltaTime*joystick.CurrentSpeedAndDirection.y;
                GetComponent<OutsideGroupSoccerAnimation>().LockForwardSpeed();
            }
            var newPositionZ = laneBasedMovementHandler.AdjustPosition(transform, joystick).z;
            transform.position = new Vector3(transform.position.x, transform.position.y, newPositionZ);
            restrictMovement(joystick);
        }

        // prevents Luis from straying off screen
        private void restrictMovement(Joystick joystickScript)
        {
            var controller = gameObject.GetComponent<ControllerMovement>();
            if (joystickScript.CurrentSpeedAndDirection.y > 0) controller.StartRunningAnimation();
            // limit character's position so it can't move behind the camera
            if (Math.Abs(controller.mainCamera.transform.position.x - transform.position.x) < 1.0f)
            {
                transform.position = new Vector3(controller.mainCamera.transform.position.x + 1.0f, transform.position.y,
                    transform.position.z);
            }
        }

        public void ResetMoveSpeed()
        {
            moveSpeed = 0f;
        }
    }
}