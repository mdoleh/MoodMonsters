using UnityEngine;

namespace GameIntro
{
    // Invisible GameObject that the adult models walk
    // into the cause them to turn 90 degrees and stop
    public class TurnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var parentMovement = other.GetComponent<ParentMovement>();
            if (parentMovement != null)
            {
                parentMovement.Turn();
            }
        }
    }
}