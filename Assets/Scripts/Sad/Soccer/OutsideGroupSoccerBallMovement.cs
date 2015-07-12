using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class OutsideGroupSoccerBallMovement : MonoBehaviour
    {
        private Rigidbody rigidBody;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        private void neutralizeForce()
        {
            rigidBody.velocity = Vector3.zero;   
        }

        public void KickBallUp()
        {
            neutralizeForce();
            rigidBody.AddForce(0f, 180f, 0f);
            rigidBody.AddTorque(0f, 0f, 100f);
        }

        public void KickBallForward()
        {
            neutralizeForce();
            rigidBody.constraints = RigidbodyConstraints.None;
            rigidBody.AddForce(250f, 180f, 0f);
            rigidBody.AddTorque(0f, 0f, -100f);
            rigidBody.angularDrag = 20f;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<SoccerAnimation>() != null)
            {
                other.GetComponent<CapsuleCollider>().enabled = false;
                other.GetComponent<SoccerAnimation>().KickForward();
            }
        }
    }
}