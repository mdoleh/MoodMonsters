using ScaredScene;
using UnityEngine;

public class EdgeSlipTrigger : MonoBehaviour
{
    private bool shouldJump = false;

    void OnTriggerEnter(Collider other)
    {
        if (!shouldJump && other.gameObject.GetComponent<FearfulMovement>() != null)
        {
            other.gameObject.GetComponent<CharacterMovement>().EdgeSlip();
            shouldJump = true;
        }
        else
        {
            other.gameObject.GetComponent<CharacterMovement>().RunJump();
        }
    }
}
