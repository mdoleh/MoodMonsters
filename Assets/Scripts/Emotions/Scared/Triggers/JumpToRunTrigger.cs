using UnityEngine;
using System.Collections;
using ScaredScene;

namespace ScaredScene
{
    // Triggers run animation on characters after they've made a jump
    public class JumpToRunTrigger : MonoBehaviour
    {
        public bool shouldPlaySound;

        private void OnTriggerEnter(Collider other)
        {
            if (shouldPlaySound && other.GetComponent<FearfulMovement>() != null)
                other.GetComponent<FearfulMovement>().JumpToRunWithAudio();
            else
                other.gameObject.GetComponent<CharacterMovement>().JumpToRun();
        }
    }
}