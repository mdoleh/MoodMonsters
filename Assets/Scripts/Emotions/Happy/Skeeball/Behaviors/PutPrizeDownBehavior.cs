using UnityEngine;

namespace HappyScene
{
    public class PutPrizeDownBehavior : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<VendorAnimations>().TakePrize();
        }
    }
}