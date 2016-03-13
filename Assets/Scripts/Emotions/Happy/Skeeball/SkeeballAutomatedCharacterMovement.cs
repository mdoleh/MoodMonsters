using System.Collections;
using UnityEngine;

namespace HappyScene
{
    public class SkeeballAutomatedCharacterMovement : MonoBehaviour
    {
        public SkeeballThrow skeeballThrow;
        public Transform skeeball;
        public Transform throwingHand;
        public GoalChooser goalChooser;
        public Camera mainCamera;
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void StartSequence()
        {
            resetBallPosition(skeeball);
            resetBallColor(skeeball);
            adjustCamera();
            StartCoroutine(rollBallDelayed());
        }

        private IEnumerator rollBallDelayed()
        {
            yield return new WaitForSeconds(1f);
            anim.SetTrigger("Throw");
        }

        public void ShiftIdleEvent()
        {
            anim.SetTrigger("Idle");
        }

        private void resetBallColor(Transform skeeball)
        {
            skeeball.GetComponent<Renderer>().material = skeeball.GetComponent<SkeeballMovementHandler>().autoColor;
        }

        public void ThrowBallEvent()
        {
            skeeball.parent = null;
            skeeball.position = new Vector3(212.913f, 4.472f, 164.257f);
            skeeball.rotation = Quaternion.Euler(Vector3.zero);
            skeeball.GetComponent<SkeeballMovementHandler>().speedFactor = 0.75f;
            skeeballThrow.ThrowBall(skeeball);
        }

        private void resetBallPosition(Transform ball)
        {
            ball.parent = throwingHand;
            ball.localPosition = new Vector3(0.001f, 0.073f, 0.069f);
            ball.rotation = Quaternion.Euler(Vector3.zero);
        }

        private void adjustCamera()
        {
            mainCamera.transform.position = new Vector3(212.092f, 5.573f, 163.023f);
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(15.00005f, 5.96f, 0f));
        }
    }
}