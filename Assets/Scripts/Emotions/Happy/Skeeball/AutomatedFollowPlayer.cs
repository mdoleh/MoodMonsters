using UnityEngine;

namespace HappyScene
{
    public class AutomatedFollowPlayer : CollectPrizeBase
    {
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
    }
}