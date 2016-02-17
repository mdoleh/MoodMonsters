using UnityEngine;
using System.Collections;

namespace HappyScene
{
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