using UnityEngine;

namespace SadScene
{
    public class OutsideGroupSoccerBallMovement : MonoBehaviour
    {
        private Rigidbody rigidBody;
        private bool shouldStartDialogue = false;

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

        public void SetDialogueFlag(bool value)
        {
            shouldStartDialogue = value;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<OutsideGroupSoccerAnimation>() != null)
            {
                other.GetComponent<CapsuleCollider>().enabled = false;
                if (shouldStartDialogue)
                    other.GetComponent<OutsideGroupSoccerAnimation>().StartDialogue();
                else
                    other.GetComponent<OutsideGroupSoccerAnimation>().KickForward();
            }
        }
    }
}