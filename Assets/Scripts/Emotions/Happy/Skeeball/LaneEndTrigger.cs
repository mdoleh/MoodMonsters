using UnityEngine;

namespace HappyScene
{
    // Used on a collider at the end of the lane to zero
    // out the force applied to the skeeball and apply new
    // forces to hit to make it move upward
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
                Utilities.StopAudio(Sound.CurrentPlayingSound);
            }
        }
    }
}