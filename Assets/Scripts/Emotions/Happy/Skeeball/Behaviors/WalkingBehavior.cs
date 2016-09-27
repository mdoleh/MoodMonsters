using UnityEngine;

namespace HappyScene
{
    // Sets the flag to make the characters move towards the Vendor to collect the prize
    public class WalkingBehavior : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<CollectPrizeBase>().StartMoving();
        }
        
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<CollectPrizeBase>().StopMoving();
        }
    }
}