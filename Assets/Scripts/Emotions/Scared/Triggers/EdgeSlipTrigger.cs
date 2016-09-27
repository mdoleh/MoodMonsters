using ScaredScene;
using UnityEngine;

namespace ScaredScene
{
    // Used on the last collider in the sequence, looks for AJ
    // then triggers a stumble animation on him, the second trigger will allow him to jump
    public class EdgeSlipTrigger : MonoBehaviour
    {
        public bool shouldJump = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!shouldJump && other.gameObject.GetComponent<FearfulMovement>() != null)
            {
                other.gameObject.GetComponent<CharacterMovement>().EdgeSlip("Stumble");
                shouldJump = true;
            }
            else if (other.gameObject.GetComponent<FearfulMovement>() != null)
            {
                other.gameObject.GetComponent<FearfulMovement>().RunJumpWithClapping();
            }
            else
            {
                other.gameObject.GetComponent<CharacterMovement>().RunJump();
            }
        }
    }
}