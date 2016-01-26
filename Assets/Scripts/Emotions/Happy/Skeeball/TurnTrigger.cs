using UnityEngine;
using System.Collections;

namespace HappyScene
{
    public class TurnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var playerCharacter = other.GetComponent<PlayerPickupPrize>();
            if (playerCharacter != null)
            {
                playerCharacter.Turn();
            }
        }
    }
}