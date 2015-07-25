using UnityEngine;
using System.Collections;
using ScaredScene;

public class SlowTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<CharacterMovement>().Walk();
    }
}
