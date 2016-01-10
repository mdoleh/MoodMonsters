using UnityEngine;

namespace GameIntro
{
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