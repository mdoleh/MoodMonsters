﻿using UnityEngine;

namespace HappyScene
{
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