using UnityEngine;
using System.Collections;

namespace SadScene
{
    // Used on parent model to trigger the question canvases to appear
    public class ParentTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterMovement>() != null)
            {
                GroupDialogue.shouldStopPlaying = true;
                other.GetComponent<CharacterMovement>().StopWalking(true);
                other.GetComponent<CapsuleCollider>().enabled = false;
                other.transform.FindChild("CameraFollow").GetComponent<CameraFollow>().enabled = false;
                GameObject.Find("ControllerCanvas").GetComponent<Canvas>().enabled = true;
                GUIHelper.NextGUI();
            }
        }
    }
}