using UnityEngine;
using System.Collections;
using ScaredScene;

namespace ScaredScene
{
    // Triggers jump animation, used on colliders towards the edges
    public class JumpTrigger : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<CharacterMovement>().RunJump();
        }
    }
}