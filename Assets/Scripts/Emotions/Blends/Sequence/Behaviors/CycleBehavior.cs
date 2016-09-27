using UnityEngine;
using System.Collections;

public class CycleBehavior : StateMachineBehaviour
{
    // Used on child models to trigger animations to swap back and forth between 2 different animations
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("Cycle");
    }
}
