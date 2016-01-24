using UnityEngine;

namespace HappyScene
{
    public class SkeeballCharacterMovement : ControllerMovement
    {
        public GoalChooser goalChooser;
        public SkeeballThrow skeeballThrow;
        private Animator anim;

        protected override void Start()
        {
            base.Start();
            anim = GetComponent<Animator>();
        }

        public void StartSequence()
        {
            mainCamera.transform.position = new Vector3(214.269f, 5.599f, 163.684f);
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(13.65f, 0f, 0f));
            if (!joystickCanvas.activeInHierarchy) GUIHelper.NextGUI();
            else ShowJoystick();
            StartJoystickTutorial();
            resetBallPosition(movementHandler.gameObject.transform);
            movementHandler.gameObject.SetActive(true);
            goalChooser.ChooseLane();
        }

        public void HideAndDisableJoystick()
        {
            trackJoystick = false;
            HideJoystick(false);
        }

        public void TakePrize()
        {
            anim.SetTrigger("TakePrize");
        }

        private void resetBallPosition(Transform ball)
        {
            ball.position = new Vector3(214.304f, 4.73f, 165.337f);
            ball.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
    }
}