using UnityEngine;

namespace HappyScene
{
    // Shared movement behavior between Ty and Scarlet as they
    // approach the Vendor to collect the prize
    public class CollectPrizeBase : MonoBehaviour
    {
        public Transform rightHand;
        public Transform prize;

        protected Animator anim;
        protected bool shouldMove = false;
        protected bool shouldMoveZ = false;
        protected int direction = 1;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void TakePrize()
        {
            anim.SetTrigger("TakePrize");
        }

        public virtual void PrizeTakenEvent()
        {
            Turn();
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

        public virtual void StartMoving()
        {
            shouldMove = true;
        }

        public virtual void StopMoving()
        {
            shouldMove = false;
            shouldMoveZ = true;
        }

        public virtual void StopWalking()
        {
            StopMoving();
            anim.SetTrigger("Idle");
        }

        protected virtual void Update()
        {
            if (shouldMove && !shouldMoveZ)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
            }
            else if (shouldMove && shouldMoveZ)
            {
                MoveInZDirection(direction);
            }
        }

        protected void MoveInZDirection(int mult)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (mult * Time.deltaTime));
        }
    }
}