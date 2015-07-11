using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class SoccerBallMovement : MonoBehaviour
    {
        public void KickBallUp()
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(0f, 180f, 0f);
            GetComponent<Rigidbody>().AddTorque(0f, 0f, 100f);
        }

        public void KickBallForward()
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(100f, 0f, 0f);
            GetComponent<Rigidbody>().AddTorque(0f, 0f, -100f);
        }
    }
}