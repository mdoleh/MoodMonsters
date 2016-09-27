using UnityEngine;
using System.Collections;
using ScaredScene;

namespace ScaredScene
{
    // Triggers the characters to run, used on colliders on the path
    public class RunTrigger : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<CharacterMovement>().Run();
        }
    }
}