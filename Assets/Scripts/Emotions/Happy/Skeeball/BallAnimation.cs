using UnityEngine;

namespace HappyScene
{
    public class BallAnimation : MonoBehaviour
    {
        public void AnimateLeftLane()
        {
            // animation stuff here
            // maybe read XML file with all positions of ball trajectory in it
            Debug.Log("Left Lane triggered");
            transform.position = new Vector3(213.934f, 5.659f, 167.881f);
        }

        public void AnimateMiddleLane()
        {
            // animation stuff here
            // maybe read XML file with all positions of ball trajectory in it
            Debug.Log("Middle Lane triggered");
            transform.position = new Vector3(214.304f, 5.603f, 167.768f);
        }

        public void AnimateRightLane()
        {
            // animation stuff here
            // maybe read XML file with all positions of ball trajectory in it
            Debug.Log("Right Lane triggered");
            transform.position = new Vector3(214.679f, 5.659f, 167.881f);
        }
    }
}