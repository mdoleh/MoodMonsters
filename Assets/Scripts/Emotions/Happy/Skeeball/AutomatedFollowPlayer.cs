using UnityEngine;

namespace HappyScene
{
    // Used on Ty to control his movements to follow Scarlet towards the Vendor
    public class AutomatedFollowPlayer : CollectPrizeBase
    {
        public CollectPrizeBase prizeWinner;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CollectPrizeBase>() != null && GetComponent<CapsuleCollider>().enabled)
            {
                StopWalking();
                GUIHelper.NextGUI();
                GetComponent<CapsuleCollider>().enabled = false;
            }
        }

        public void ShiftSad()
        {
            anim.SetTrigger("Idle");
        }

        public override void PrizeTakenEvent()
        {
            var rigidBody = GetComponent<Rigidbody>();
            if (rigidBody != null) rigidBody.constraints = RigidbodyConstraints.None;
            anim.SetTrigger("Happy");
            prizeWinner.Idle();
        }

        public void ReturnToOriginalSpot()
        {
            direction = -1;
            anim.SetTrigger("WalkBackwards");
        }

        protected override void Update()
        {
            base.Update();
            if (shouldMove && shouldMoveZ)
            {
                if (transform.position.z >= 164.562f)
                {
                    StopMoving();
                    anim.SetTrigger("HighFive");
                    prizeWinner.GetComponent<Animator>().SetTrigger("HighFive");
                }
                if (direction == -1 && transform.position.z <= 163.9075f)
                {
                    StopMoving();
                    anim.SetTrigger("Idle");
                    direction = 1;
                }
            }
        }
    }
}