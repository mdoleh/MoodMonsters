using UnityEngine;

namespace HappyScene
{
    public class AutomatedFollowPlayer : CollectPrizeBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CollectPrizeBase>() != null)
            {
                StopWalking();
                GUIHelper.NextGUI();
            }
        }
    }
}