using ScaredScene;
using UnityEngine;

public class EdgeSlipTrigger : MonoBehaviour
{
    private bool toggle = false;

    void OnTriggerEnter(Collider other)
    {
        if (!toggle)
        {
            other.gameObject.GetComponent<CharacterMovement>().RunJump();
        }
        else
        {
            other.gameObject.GetComponent<CharacterMovement>().EdgeSlip();
        }
        toggle = !toggle;
    }
}
