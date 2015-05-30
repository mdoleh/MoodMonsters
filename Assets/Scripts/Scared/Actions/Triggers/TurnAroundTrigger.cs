using UnityEngine;
using System.Collections;
using ScaredScene;

public class TurnAroundTrigger : MonoBehaviour
{
    public bool shouldTurnAround = true;

    void OnTriggerEnter(Collider other)
    {
        if (shouldTurnAround)
        {
            other.gameObject.GetComponent<CharacterMovement>().TurnAround();
        }
        else
        {
            shouldTurnAround = true;
        }
    }
}
