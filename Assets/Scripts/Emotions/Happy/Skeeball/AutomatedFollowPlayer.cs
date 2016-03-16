using UnityEngine;

namespace HappyScene
{
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

        protected override void Update()
        {
            base.Update();

        }
    }
}