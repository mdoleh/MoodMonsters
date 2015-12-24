using UnityEngine;

namespace HappyScene
{
    public class SkeeballCharacterMovement : ControllerMovement
    {
        private Animator anim;

        public void StartSequence()
        {
            // place character in "skeeball ready" idle pose
            //anim.SetTrigger("");
            mainCamera.transform.position = new Vector3(214.269f, 5.77f, 163.522f);
            GUIHelper.NextGUI();
            StartJoystickTutorial();
            LaneAppear.shouldShowLanes = true;
        }
    }
}