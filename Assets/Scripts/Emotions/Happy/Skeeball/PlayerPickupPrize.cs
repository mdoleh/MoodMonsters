using UnityEngine;

namespace HappyScene
{
    public class PlayerPickupPrize : MonoBehaviour
    {
        public VendorAnimations vendor;
        public Camera mainCamera;
        public Transform rightHand;
        public Transform prize;

        private Animator anim;
        private bool shouldMove = false;
        private bool shouldMoveZ = false;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void TakePrize()
        {
            anim.SetTrigger("TakePrize");
        }

        public void PrizeTakenEvent()
        {
            Turn();
            vendor.Idle();
        }

        public void MovePrizeToHandEvent()
        {
            prize.parent = rightHand;
            prize.position = rightHand.position;
        }

        public void AdjustPrizePosition()
        {
            prize.localPosition = new Vector3(-0.1590579f, 0.1720701f, 0.03714781f);
//            prize.position = new Vector3(216.5865f, 4.913111f, 164.7747f);
            prize.localRotation = Quaternion.Euler(new Vector3(297.1701f, 61.78062f, 22.98684f));
//            prize.rotation = Quaternion.Euler(new Vector3(350.1668f, 187.73f, 334.5417f));
        }

        public void Idle()
        {
            anim.SetTrigger("Idle");
        }

        public void Turn()
        {
            anim.SetTrigger("TurnAround");
        }

        public void WalkEvent()
        {
            anim.SetTrigger("Walk");
        }

        public void StartMoving()
        {
            shouldMove = true;
            GetComponent<CameraFollow>().enabled = true;
        }

        public void StopMoving()
        {
            shouldMove = false;
            shouldMoveZ = true;
            GetComponent<CameraFollow>().enabled = false;
        }

        public void StopWalking()
        {
            StopMoving();
            anim.SetTrigger("Idle");
            mainCamera.transform.position = new Vector3(219.819f, 5.665f, 165.045f);
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(13f, 270f, 0f));
        }

        private void Update()
        {
            if (shouldMove && !shouldMoveZ)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
            }
            else if (shouldMove && shouldMoveZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime);
            }
        }
    }
}