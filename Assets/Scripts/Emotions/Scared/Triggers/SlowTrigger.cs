using UnityEngine;
using System.Collections;
using ScaredScene;

namespace ScaredScene
{
    // Triggers the characters to walk, used on colliders after JumpToRun
    public class SlowTrigger : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<CharacterMovement>().Walk();
        }
    }
}