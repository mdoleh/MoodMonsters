using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SadScene
{
    public class GroupSoccerBallMovement : MonoBehaviour {

        private Rigidbody rigidBody;
        private readonly IList<string> kickDirections = 
            new List<string> { "KickForward", "KickLeft", "KickRight" };

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        public void NeutralizeForce()
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
        }

        public void KickBallForward(Vector3 direction)
        {
            NeutralizeForce();
            rigidBody.AddForce(direction * 100f);
        }

        public void KickBallLeft()
        {
            NeutralizeForce();
            rigidBody.AddForce(50f, 0f, 0f);
        }

        public void KickBallRight()
        {
            NeutralizeForce();
            rigidBody.AddForce(50f, 0f, 0f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<GroupSoccerAnimation>() != null)
            {
                other.GetComponent<CapsuleCollider>().enabled = false;
                kickInRandomDirection(other.GetComponent<GroupSoccerAnimation>());
            }
        }

        private void kickInRandomDirection(GroupSoccerAnimation other)
        {
            var direction = Random.Range(0, 2);
            direction = 0;
            var method = other.GetType().GetMethod(kickDirections[direction]);
            method.Invoke(other, null);
        }
    }
}

