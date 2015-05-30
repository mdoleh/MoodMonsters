using UnityEngine;
using System.Collections;
using ScaredScene;

public class JumpDownTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CharacterMovement>().JumpDown();
    }
}
