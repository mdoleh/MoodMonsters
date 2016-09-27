using UnityEngine;

namespace HappyScene
{
    // Triggers the animation on Scarlet to take the prize from the Vendor
    public class PutPrizeDownBehavior : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<VendorAnimations>().TakePrize();
        }
    }
}