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

        public void KickBallForward(Vector3 direction, float force)
        {
            NeutralizeForce();
            rigidBody.AddForce(direction * force);
        }

        public void KickBallLateral(Vector3 direction)
        {
            NeutralizeForce();
            rigidBody.AddForce(direction * 100f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<GroupSoccerAnimation>() != null)
            {
                other.GetComponent<CapsuleCollider>().enabled = false;
                kickInRandomDirection(other.GetComponent<GroupSoccerAnimation>());
            }
            else if (other.GetComponent<ForceIntoGame>() != null)
            {
                other.GetComponent<ForceIntoGame>().ForceKickBallForward();
            }
        }

        private void kickInRandomDirection(GroupSoccerAnimation other)
        {
            var direction = Random.Range(0, 2);
            var method = other.GetType().GetMethod(kickDirections[direction]);
            method.Invoke(other, null);
        }
    }
}

