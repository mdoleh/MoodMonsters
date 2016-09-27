using UnityEngine;
using System.Collections;

namespace SadScene
{
    // Collider that when the soccerball passes through sets a
    // flag that determines when the dialogue between characters should begin
    public class SequenceTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<OutsideGroupSoccerBallMovement>() != null)
            {
                other.GetComponent<OutsideGroupSoccerBallMovement>().SetDialogueFlag(true);
            }
        }
    }
}