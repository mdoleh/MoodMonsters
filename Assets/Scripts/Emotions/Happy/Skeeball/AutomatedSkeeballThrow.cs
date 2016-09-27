using Globals;
using UnityEngine;

namespace HappyScene
{
    // Controls how Ty throws the skeeball
    // Shifts control back to Scarlet after his throw
    public class AutomatedSkeeballThrow : SkeeballThrow
    {
        public SkeeballCharacterMovement playerCharacter;

        public override void ResetForNextThrow(Transform ball)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
            Utilities.StopAudio(ball.GetComponent<AudioSource>());
            ball.GetComponent<BallAnimation>().NeutralizeForce();
            ball.GetComponent<Rigidbody>().useGravity = false;
            Timeout.StartTimers();
            playerCharacter.StartSequence();
        }
    }
}