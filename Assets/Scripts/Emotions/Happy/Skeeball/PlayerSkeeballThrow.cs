using UnityEngine;

namespace HappyScene
{
    public class PlayerSkeeballThrow : SkeeballThrow
    {
        public SkeeballAutomatedCharacterMovement automatedCharacter;
        public VendorAnimations vendor;
        public SkeeballScore skeeballScore;
        public const int MAX_SCORE = 400;

        private GoalChooser goalChooser;
        private Camera mainCamera;

        private void Start()
        {
            goalChooser = GetComponent<SkeeballCharacterMovement>().goalChooser;
            mainCamera = GetComponent<SkeeballCharacterMovement>().mainCamera;
        }

        public override void ThrowBall(Transform ball)
        {
            base.ThrowBall(ball);
            GetComponent<SkeeballCharacterMovement>().HideAndDisableJoystick();
        }

        public override void ResetForNextThrow(Transform ball)
        {
            if (skeeballScore.Score >= MAX_SCORE)
            {
                stopSkeeball(ball);
                winPrize();
            }
            else
            {
                base.ResetForNextThrow(ball);
                automatedCharacter.StartSequence();
            }
        }

        private void stopSkeeball(Transform ball)
        {
            ball.gameObject.SetActive(false);
            goalChooser.HideAllHighlighers();
            mainCamera.transform.position = new Vector3(213.64f, 6.42f, 162.15f);
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(25.3244f, 0f, 0f));
        }

        private void winPrize()
        {
            vendor.WonPrize();
        }
    }
}