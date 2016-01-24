using UnityEngine;

namespace HappyScene
{
    public class LaneEndTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var ballAnimation = other.GetComponent<BallAnimation>();
            if (ballAnimation != null)
            {
                ballAnimation.NeutralizeForce();
                float speedFactor = other.GetComponent<SkeeballMovementHandler>().speedFactor;
                other.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                other.GetComponent<Rigidbody>().AddForce(other.transform.forward * 75f);
                other.GetComponent<Rigidbody>().AddForce(other.transform.up * (250f * speedFactor));
            }
        }
    }
}