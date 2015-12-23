using UnityEngine;

namespace HappyScene
{
    public class SkeeballMovementHandler : MovementHandler
    {
        public LaneBasedMovementHandler laneBasedMovementHandler;

        public override void HandleMovement(Joystick joystick)
        {
            var newPositionX = laneBasedMovementHandler.AdjustPosition(transform, joystick).x;
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }
    }
}