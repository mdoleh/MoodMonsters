using UnityEngine;

namespace HappyScene
{
    public class ExcitedBehavior : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<CollectPrizeBase>().AdjustPrizePosition();
        }
    }
}