using System;
using UnityEngine;

public class BasicCameraMovements : MonoBehaviour
{
    public float PAN_SPEED = 0.01f;

    private bool panUp;
    private bool panDown;
    private bool panLeft;
    private bool panRight;

    private Func<Vector3, bool> conditionUp;
    private Func<Vector3, bool> conditionDown;
    private Func<Vector3, bool> conditionLeft;
    private Func<Vector3, bool> conditionRight; 

    public void PanLeft(Func<Vector3, bool> condition)
    {
        panLeft = true;
        conditionLeft = condition;
    }

    public void PanRight(Func<Vector3, bool> condition)
    {
        panRight = true;
        conditionRight = condition;
    }

    public void PanUp(Func<Vector3, bool> condition)
    {
        panUp = true;
        conditionUp = condition;
    }

    public void PanDown(Func<Vector3, bool> condition)
    {
        panDown = true;
        conditionDown = condition;
    }

    public void ResetFlags()
    {
        panUp = false;
        panDown = false;
        panLeft = false;
        panRight = false;

        conditionUp = null;
        conditionDown = null;
        conditionLeft = null;
        conditionRight = null; 
    }

    private void Update()
    {
        if (panUp)
        {
            transform.position += transform.up * PAN_SPEED;
            if (conditionUp(transform.position)) panUp = false;
        }
        if (panDown)
        {
            transform.position -= transform.up * PAN_SPEED;
            if (conditionDown(transform.position)) panDown = false;
        }
        if (panLeft)
        {
            transform.position -= transform.right * PAN_SPEED;
            if (conditionLeft(transform.position)) panLeft = false;
        }
        if (panRight)
        {
            transform.position += transform.right * PAN_SPEED;
            if (conditionRight(transform.position)) panRight = false;
        }
    }
}
