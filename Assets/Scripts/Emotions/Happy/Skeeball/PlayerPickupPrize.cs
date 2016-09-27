using UnityEngine;

namespace HappyScene
{
    // Used on Scarlet for her custom behavior to move towards the Vendor and collect the prize
    public class PlayerPickupPrize : CollectPrizeBase
    {
        public VendorAnimations vendor;
        public AutomatedFollowPlayer automatedCharacter;
        public Camera mainCamera;

        public void AutomatedFollow()
        {
            automatedCharacter.Turn();
        }

        public override void PrizeTakenEvent()
        {
            Turn();
            vendor.Idle();
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