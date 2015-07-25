using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class ParentTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterMovement>() != null)
            {
                other.GetComponent<CharacterMovement>().StopWalking();
                other.GetComponent<CapsuleCollider>().enabled = false;
                other.transform.FindChild("CameraFollow").GetComponent<CameraFollow>().enabled = false;
                GameObject.Find("ControllerCanvas").GetComponent<Canvas>().enabled = true;
                GUIDetect.NextGUI();
            }
        }
    }
}