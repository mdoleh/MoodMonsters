using UnityEngine;
using System.Collections;
using ScaredScene;

public class TurnAroundTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<CharacterMovement>().TurnAround();
    }
}
