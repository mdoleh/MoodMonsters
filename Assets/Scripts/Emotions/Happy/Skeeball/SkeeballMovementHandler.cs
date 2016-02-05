using System;
using UnityEngine;

namespace HappyScene
{
    public class SkeeballMovementHandler : MovementHandler
    {
        [HideInInspector]
        public float speedFactor = 0f;

        public SkeeballThrow thrower;
        public Material playerColor;
        public Material autoColor;
        [Header("Horizontal Restrictions")]
        public float minX;
        public float maxX;

        [Header("Debugging")]
        public float defaultSpeed = 1500f;

        public override void HandleMovement(Joystick joystick)
        {
            float speed = 0f;
            float moveDirection = Time.deltaTime * joystick.CurrentSpeedAndDirection.x;
            transform.position = new Vector3(transform.position.x + moveDirection, transform.position.y, transform.position.z);
            restrictMovement();
            if (Input.touches.Length > 0)
            {
                speed = (Input.touches[0].deltaPosition/Time.deltaTime).y;
            }
            else speed = defaultSpeed;
            if (joystick.CurrentSpeedAndDirection.y >= 2.0f)
            {
                Debug.Log("speed: " + speed);
                speedFactor = computeSpeedFactor(speed);
                thrower.ThrowBall(transform);
            }
        }

        private float computeSpeedFactor(float speed)
        {
            if (speed >= 1500f)
            {
                return 1f;
            }
            if (speed < 1500f && speed >= 400f)
            {
                return 0.8f;
            }
            return 0.75f;
        }

        public override void OverrideMovement(float moveSpeed, float moveDirection)
        {
            // do nothing
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