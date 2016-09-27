using UnityEngine;

namespace HappyScene
{
    // Adjusts the bear in Scarlet's hand when this animation is triggered
    public class ExcitedBehavior : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<CollectPrizeBase>().AdjustPrizePosition();
        }
    }
}