using UnityEngine;
using System.Collections;

namespace SadScene
{
    // Triggers a toy bear to appear in Luis's hand to help with the "hugging toys" hint
    public class HuggingBehavior : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<Toy>().ToyToHug.SetActive(true);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<Toy>().ToyToHug.SetActive(false);
        }
    }
}