using UnityEngine;

namespace HappyScene
{
    public class SkeeballThrow : MonoBehaviour
    {
        public virtual void ThrowBall(Transform ball)
        {
            Utilities.PlayAudio(ball.GetComponent<AudioSource>());
            var ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.useGravity = true;
            ballRigidbody.AddForce(ball.forward * 300f);
        }

        public virtual void ResetForNextThrow(Transform ball)
        {
            Utilities.StopAudio(ball.GetComponent<AudioSource>());
            ball.GetComponent<BallAnimation>().NeutralizeForce();
            ball.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}