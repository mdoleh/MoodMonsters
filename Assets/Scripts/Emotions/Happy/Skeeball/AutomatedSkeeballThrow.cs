using UnityEngine;

namespace HappyScene
{
    public class AutomatedSkeeballThrow : SkeeballThrow
    {
        public SkeeballCharacterMovement playerCharacter;

        public override void ResetForNextThrow(Transform ball)
        {
            Utilities.StopAudio(ball.GetComponent<AudioSource>());
            ball.GetComponent<BallAnimation>().NeutralizeForce();
            ball.GetComponent<Rigidbody>().useGravity = false;
            playerCharacter.StartSequence();
        }
    }
}