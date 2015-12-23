using UnityEngine;
using System.Collections;

namespace HappyScene
{
    public class SkeeballMovementHandler : MovementHandler
    {
        public LaneBasedMovementHandler laneBasedMovementHandler;

        public override void HandleMovement(Joystick joystick)
        {
            laneBasedMovementHandler.AdjustPosition(transform, joystick);
        }
    }
}