using UnityEngine;

namespace HappyScene
{
    public class SkeeballCharacterMovement : ControllerMovement
    {
        public LaneChooser laneChooser;
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
            Utilities.StopAudio(ball.GetComponent<AudioSource>());
            laneChooser.ChooseLane();
            EnableJoystick();
            ShowJoystick();
        }

        private void animateThrowBall()
        {
            //anim.SetTrigger("Throw");
        }
    }
}