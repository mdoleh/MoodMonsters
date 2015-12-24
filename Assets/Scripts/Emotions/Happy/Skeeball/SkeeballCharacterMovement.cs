using UnityEngine;

namespace HappyScene
{
    public class SkeeballCharacterMovement : ControllerMovement
    {
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
            mainCamera.transform.position = new Vector3(214.269f, 5.77f, 163.522f);
            GUIHelper.NextGUI();
            StartJoystickTutorial();
            LaneAppear.shouldShowLanes = true;
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
            EnableJoystick();
            ShowJoystick();
        }

        private void animateThrowBall()
        {
            //anim.SetTrigger("Throw");
        }
    }
}