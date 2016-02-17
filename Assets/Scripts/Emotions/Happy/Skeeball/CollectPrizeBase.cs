using UnityEngine;

namespace HappyScene
{
    public class CollectPrizeBase : MonoBehaviour
    {
        protected Animator anim;
        protected bool shouldMove = false;
        protected bool shouldMoveZ = false;

        private void Start()
        {
            anim = GetComponent<Animator>();
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
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;
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