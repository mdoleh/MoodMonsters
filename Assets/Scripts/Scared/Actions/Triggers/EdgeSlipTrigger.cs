using UnityEngine;
using System.Collections;
using ScaredScene;

public class EdgeSlipTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.ToLower().Contains("scarlet"))
            other.gameObject.GetComponent<CharacterMovement>().RunJump();
        else
            other.gameObject.GetComponent<CharacterMovement>().EdgeSlip();
    }
}
