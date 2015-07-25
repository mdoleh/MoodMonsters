using UnityEngine;
using System.Collections;
using ScaredScene;

public class RunTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<CharacterMovement>().Run();
    }
}
