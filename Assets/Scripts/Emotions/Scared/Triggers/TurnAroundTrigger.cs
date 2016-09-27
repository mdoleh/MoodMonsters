using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ScaredScene;

namespace ScaredScene
{
    // Triggers Scarlet to turn around after making a jump to wait for AJ
    public class TurnAroundTrigger : MonoBehaviour
    {
        public bool shouldTurnAround = true;
        private readonly IList<string> characters = new List<string>();

        private void OnTriggerEnter(Collider other)
        {
            if (shouldTurnAround && !characters.Contains(other.name))
            {
                other.gameObject.GetComponent<CharacterMovement>().TurnAround();
                characters.Add(other.name);
            }
            else
            {
                shouldTurnAround = true;
            }
        }
    }
}