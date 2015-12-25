using UnityEngine;

namespace HappyScene
{
    public class SkeeballCharacterMovement : ControllerMovement
    {
        public LaneChooser laneChooser;
        public const int MAX_SCORE = 400;
        private Animator anim;

        protected override void Start()
        {
            base.Start();
            anim = GetComponent<Animator>();
        }

        public void StartSequence()
        {
            // place character in "skeeball ready" idle pose
            //anim.SetTrigger("Idle");
            mainCamera.transform.position = new Vector3(214.269f, 5.599f, 163.684f);
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(13.65f, 0f, 0f));
            GUIHelper.NextGUI();
            StartJoystickTutorial();
            movementHandler.gameObject.SetActive(true);
            LaneAppear.shouldShowLanes = true;
            laneChooser.ChooseLane();
        }

        public void ThrowBall(Transform ball)
        {
            // Todo: attach ball as child of her hand and animate her throwing it
            animateThrowBall();
            Utilities.PlayAudio(ball.GetComponent<AudioSource>());
            trackJoystick = false;
            multiplierSpeed = 2.0f;
            HideJoystick(false);
        }

        public void ResetForNextThrow(Transform ball)
        {
            if (SkeeballScore.Score >= MAX_SCORE)
            {
                stopSkeeball(ball);
                winPrize();
            }
            else
            {
                Utilities.StopAudio(ball.GetComponent<AudioSource>());
                laneChooser.ChooseLane();
                EnableJoystick();
                ShowJoystick();
            }
        }

        private void animateThrowBall()
        {
            //anim.SetTrigger("Throw");
        }

        private void winPrize()
        {
            // animation sequence to win prize
        }

        private void stopSkeeball(Transform ball)
        {
            ball.gameObject.SetActive(false);
            laneChooser.HideAllHighlighers();
            mainCamera.transform.position = new Vector3(213.64f, 6.42f, 162.15f);
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(25.3244f, 0f, 0f));
        }
    }
}