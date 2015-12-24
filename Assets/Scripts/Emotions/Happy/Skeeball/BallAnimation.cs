using UnityEngine;
using System.Collections;
using HappyScene;

public class BallAnimation : MonoBehaviour
{
    public SkeeballCharacterMovement thrower;

    public void AnimateLeftLane()
    {
        // animation stuff here
        // maybe read XML file with all positions of ball trajectory in it
        Debug.Log("Left Lane triggered");
        resetBall();
    }

    public void AnimateMiddleLane()
    {
        // animation stuff here
        // maybe read XML file with all positions of ball trajectory in it
        Debug.Log("Middle Lane triggered");
        resetBall();
    }

    public void AnimateRightLane()
    {
        // animation stuff here
        // maybe read XML file with all positions of ball trajectory in it
        Debug.Log("Right Lane triggered");
        resetBall();
    }

    private void resetBall()
    {
        transform.GetComponent<LaneBasedMovementHandler>().currentIndex = 1;
        transform.position = new Vector3(214.304f, 4.73f, 164.882f);
        thrower.ResetForNextThrow(transform);
    }
}
