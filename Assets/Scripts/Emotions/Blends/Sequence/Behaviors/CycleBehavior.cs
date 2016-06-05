using UnityEngine;
using System.Collections;

public class CycleBehavior : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("Cycle");
    }
}
