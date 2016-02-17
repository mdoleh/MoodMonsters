using EggCatch;
using UnityEngine;

namespace AngryScene
{
    public class BucketScript : PlayerScript
    {
        public Animator Lily;
        private float animationDelay = 0.0f;

        protected override void Update()
        {
            float moveInput = (Input.mousePosition.x / Screen.width) * 5f;
            
            animationDelay += Time.deltaTime;
            if (animationDelay >= 1)
            {
                Lily.ResetTrigger("SwipeRight");
                Lily.ResetTrigger("SwipeLeft");
                Lily.SetTrigger(moveInput > 0 ? "SwipeRight" : "SwipeLeft");
                animationDelay = 0.0f;
            }

            transform.position = new Vector3(Mathf.Clamp(moveInput - 2.5f, -2.5f, 2.5f), transform.position.y, transform.position.z);

            lastInput = moveInput;
        }

        public override void UpdateScore(int value)
        {
            // do nothing
        }
    }
}