using UnityEngine;
using System.Collections;
using ScaredScene;

namespace ScaredScene
{
    // Triggers the characters to walk, used on colliders after Slow triggers
    public class WalkTrigger : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<CharacterMovement>().RunToWalk();
        }
    }
}