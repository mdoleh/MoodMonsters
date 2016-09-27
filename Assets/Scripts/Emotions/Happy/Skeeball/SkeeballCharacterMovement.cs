using System.Collections;
using HelpGUI;
using UnityEngine;

namespace HappyScene
{
    // Controls the player's interactions with the joystick to
    // control when the skeeball gets thrown
    public class SkeeballCharacterMovement : ControllerMovement
    {
        public GoalChooser goalChooser;
        public SkeeballThrow skeeballThrow;

        public void StartSequence()
        {
            mainCamera.transform.position = new Vector3(214.269f, 5.599f, 163.684f);
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(13.65f, 0f, 0f));
            if (!joystickCanvas.activeInHierarchy)
            {
                GUIHelper.NextGUI();
                StartCoroutine(goalChooser.FlashBonusHighlighters());
            }
            ShowJoystick();
            HelpCanvas.Interactive(true);
            HelpCanvas.EnableHintButton(false);
            StartCoroutine(startSequence());
        }

        private IEnumerator startSequence()
        {
            yield return PlayJoystickInstructions();
            goalChooser.StopFlashingHighlighters();
            resetBallPosition(movementHandler.gameObject.transform);
            resetBallColor(movementHandler.gameObject.transform);
            movementHandler.gameObject.SetActive(true);
            goalChooser.ChooseLane();
        }

        public void HideAndDisableJoystick()
        {
            trackJoystick = false;
            HideJoystick(false);
        }

        private void resetBallPosition(Transform ball)
        {
            ball.position = new Vector3(214.304f, 4.73f, 165.337f);
            ball.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }

        private void resetBallColor(Transform ball)
        {
            ball.GetComponent<Renderer>().material = ball.GetComponent<SkeeballMovementHandler>().playerColor;
        }
    }
}