using UnityEngine;

namespace AngryScene
{
    public class SharingBehavior : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var iPad = GameObject.Find("iPad").transform;
            iPad.localPosition = new Vector3(-0.005f, 0.168f, 0.056f);
            iPad.localRotation = Quaternion.Euler(new Vector3(5.834772f, 347.5904f, 11.9093f));
        }
    }
}