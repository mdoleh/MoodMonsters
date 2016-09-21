using System;
using UnityEngine;

// Creates simple camera panning movements
// Used by the Game Introduction
public class BasicCameraMovements : MonoBehaviour
{
    private float PAN_SPEED;

    private bool panUp;
    private bool panDown;
    private bool panLeft;
    private bool panRight;

    private Vector3 finalPosition;


    public void PanLeft(Vector3 finalPosition, float timeToMove)
    {
        panLeft = true;
        PAN_SPEED = Math.Abs(transform.position.x - finalPosition.x) / timeToMove;
        this.finalPosition = finalPosition;
    }

    public void PanRight(Vector3 finalPosition, float timeToMove)
    {
        panRight = true;
        PAN_SPEED = Math.Abs(transform.position.x - finalPosition.x) / timeToMove;
        this.finalPosition = finalPosition;
    }

    public void PanUp(Vector3 finalPosition, float timeToMove)
    {
        panUp = true;
        PAN_SPEED = Math.Abs(transform.position.y - finalPosition.y) / timeToMove;
        this.finalPosition = finalPosition;
    }

    public void PanDown(Vector3 finalPosition, float timeToMove)
    {
        panDown = true;
        PAN_SPEED = Math.Abs(transform.position.y - finalPosition.y) / timeToMove;
        this.finalPosition = finalPosition;
    }

    public void ResetFlags()
    {
        panUp = false;
        panDown = false;
        panLeft = false;
        panRight = false;

        finalPosition = Vector3.zero;
    }

    private void Update()
    {
        if (panUp)
        {
            transform.position += transform.up * Time.deltaTime * PAN_SPEED;
            if (transform.position.y >= finalPosition.y) panUp = false;
        }
        if (panDown)
        {
            transform.position -= transform.up * Time.deltaTime * PAN_SPEED;
            if (transform.position.y <= finalPosition.y) panDown = false;
        }
        if (panLeft)
        {
            transform.position -= transform.right * Time.deltaTime * PAN_SPEED;
            if (transform.position.x >= finalPosition.x) panLeft = false;
        }
        if (panRight)
        {
            transform.position += transform.right * Time.deltaTime * PAN_SPEED;
            if (transform.position.x <= finalPosition.x) panRight = false;
        }
    }
}
