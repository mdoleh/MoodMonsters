using UnityEngine;

namespace HappyScene 
{
    public class BackPanelTrigger : MonoBehaviour
    {
        private static bool hasTriggered = false;

        private void OnCollisionEnter(Collision collision)
        {
            var other = collision.collider;
            var ballAnimation = other.GetComponent<BallAnimation>();
            if (!hasTriggered && ballAnimation != null)
            {
                ballAnimation.NeutralizeForce();
                other.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                hasTriggered = true;
            }
        }

        public static void ResetBackPanel()
        {
            hasTriggered = false;
        }
    }
}