using UnityEngine;

namespace HappyScene
{
    // Used to reset the physics on the skeeball to neutral so
    // that additional added physics are not interfered with
    public class BallAnimation : MonoBehaviour
    {
        private Rigidbody rigidBody;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        public void NeutralizeForce()
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}