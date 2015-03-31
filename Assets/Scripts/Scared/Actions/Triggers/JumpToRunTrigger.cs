using UnityEngine;
using System.Collections;
using ScaredScene;

public class JumpToRunTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<CharacterMovement>().JumpToRun();
    }
}
