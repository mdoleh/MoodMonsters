using ScaredScene;
using UnityEngine;

public class EdgeSlipTrigger : MonoBehaviour
{
    public bool AlwaysStumble = false;
    public bool shouldJump = false;

    void OnTriggerEnter(Collider other)
    {
        if (!shouldJump && other.gameObject.GetComponent<FearfulMovement>() != null)
        {
            other.gameObject.GetComponent<CharacterMovement>().EdgeSlip("Stumble");
            shouldJump = true;
        }
        else
        {
            other.gameObject.GetComponent<CharacterMovement>().RunJump();
        }
    }
}
