using System;
using UnityEngine;

namespace HappyScene
{
    public class SkeeballMovementHandler : MovementHandler
    {
        public SkeeballCharacterMovement thrower;
        [Header("Horizontal Restrictions")]
        public float minX;
        public float maxX;

        public override void HandleMovement(Joystick joystick)
        {
            float moveDirection = Time.deltaTime * joystick.CurrentSpeedAndDirection.x;
            transform.position = new Vector3(transform.position.x + moveDirection, transform.position.y, transform.position.z);
            restrictMovement();

            if (joystick.CurrentSpeedAndDirection.y >= 2.0f)
            {
                thrower.ThrowBall(transform);
            }
        }

        public override void OverrideMovement(float moveSpeed, float moveDirection)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed);
        }

        private void restrictMovement()
        {
            var mainCamera = GameObject.Find("MainCamera");
            // limit character's position so it can't move behind the camera
            if (Math.Abs(mainCamera.transform.position.z - transform.position.z) < 1.3f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z + 1.3f);
            }
            if (transform.position.x <= minX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }
            if (transform.position.x >= maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            }
        }
    }
}