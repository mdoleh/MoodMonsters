using System.Collections;
using UnityEngine;

namespace HappyScene
{
    public class SkeeballAutomatedCharacterMovement : MonoBehaviour
    {
        public SkeeballThrow skeeballThrow;
        public Transform skeeball;
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
            adjustCamera();
//            anim.SetTrigger("Throw");
            // TODO: this is temporary, should be called by an animation event
            StartCoroutine(throwBall());
        }

        private IEnumerator throwBall()
        {
            yield return new WaitForSeconds(1.5f);
            ThrowBallEvent();
        }

        public void ThrowBallEvent()
        {
            skeeball.GetComponent<SkeeballMovementHandler>().speedFactor = 0.75f;
            skeeballThrow.ThrowBall(skeeball);
        }

        private void resetBallPosition(Transform ball)
        {
            // TODO: put the ball in his hand
            ball.position = new Vector3(212.913f, 4.472f, 164.257f);
            ball.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }

        private void adjustCamera()
        {
            mainCamera.transform.position = new Vector3(215.008f, 5.553f, 165.528f);
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(13f, 270f, 0f));
        }
    }
}