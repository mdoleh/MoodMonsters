using HappyScene;
using UnityEngine;

namespace HappyScene
{
    public class LaneEndTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var ballAnimation = other.GetComponent<BallAnimation>();
            if (ballAnimation != null)
            {
                var method = ballAnimation.GetType().GetMethod("Animate" + transform.parent.name + "Lane");
                method.Invoke(ballAnimation, new object[] {LaneChooser.correctLane.name == transform.parent.name});
            }
        }
    }
}