using UnityEngine;
using System.Collections;

namespace HappyScene
{
    // Collider used to indicate to the models when to start turning
    // Also triggers the automated character (Ty) to start moving once
    // the Scarlet passing over the trigger
    public class TurnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var character = other.GetComponent<CollectPrizeBase>();
            if (character != null)
            {
                character.Turn();
            }
            var player = other.GetComponent<PlayerPickupPrize>();
            if (player != null)
            {
                player.AutomatedFollow();
            }
        }
    }
}