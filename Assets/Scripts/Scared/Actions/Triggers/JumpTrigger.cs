using UnityEngine;
using System.Collections;
using ScaredScene;

public class JumpTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<CharacterMovement>().RunJump();
    }
}
