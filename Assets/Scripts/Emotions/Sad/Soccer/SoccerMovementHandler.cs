using UnityEngine;

public class SoccerMovementHandler : MovementHandler
{
    public LaneBasedMovementHandler laneBasedMovementHandler;

    public override void HandleMovement(Joystick joystick)
    {
        float moveSpeed = Time.deltaTime * joystick.CurrentSpeedAndDirection.y;
        transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
        laneBasedMovementHandler.AdjustPosition(transform, joystick);
    }
}
