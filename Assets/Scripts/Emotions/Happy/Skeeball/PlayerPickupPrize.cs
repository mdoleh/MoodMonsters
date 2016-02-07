using UnityEngine;

namespace HappyScene
{
    public class PlayerPickupPrize : CollectPrizeBase
    {
        public VendorAnimations vendor;
        public AutomatedFollowPlayer automatedCharacter;
        public Camera mainCamera;
        public Transform rightHand;
        public Transform prize;

        public void AutomatedFollow()
        {
            automatedCharacter.Turn();
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
            prize.localRotation = Quaternion.Euler(new Vector3(297.1701f, 61.78062f, 22.98684f));
        }

        public override void StartMoving()
        {
            base.StartMoving();
            GetComponent<CameraFollow>().enabled = true;
        }

        public override void StopMoving()
        {
            base.StopMoving();
            GetComponent<CameraFollow>().enabled = false;
        }

        public override void StopWalking()
        {
            base.StopWalking();
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