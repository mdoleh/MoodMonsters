using System.Collections;
using UnityEngine;

// base class for customized movement behavior
public abstract class MovementHandler : MonoBehaviour
{
    public abstract void HandleMovement(Joystick joystick);

    public virtual void OverrideMovement(float moveSpeed, float moveDirection)
    {
        transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z - moveDirection);
    }
}
