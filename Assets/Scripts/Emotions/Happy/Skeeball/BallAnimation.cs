using UnityEngine;

namespace HappyScene
{
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