using UnityEngine;
using System.Collections;
using ScaredScene;

public class WalkTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<CharacterMovement>().RunToWalk();
    }
}
