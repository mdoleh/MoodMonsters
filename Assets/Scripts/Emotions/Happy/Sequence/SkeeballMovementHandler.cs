using System;
using UnityEngine;

namespace HappyScene
{
    public class SkeeballMovementHandler : MovementHandler
    {
        public LaneBasedMovementHandler laneBasedMovementHandler;

        public override void HandleMovement(Joystick joystick)
        {
            var newPositionX = laneBasedMovementHandler.AdjustPosition(transform, joystick).x;
            float moveSpeed = Time.deltaTime * joystick.CurrentSpeedAndDirection.y;
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z + moveSpeed);
            restrictMovement();
        }

        private void restrictMovement()
        {
            var mainCamera = GameObject.Find("MainCamera");
            // limit character's position so it can't move behind the camera
            if (Math.Abs(mainCamera.transform.position.z - transform.position.z) < 1.0f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z + 1.0f);
            }
        }
    }
}