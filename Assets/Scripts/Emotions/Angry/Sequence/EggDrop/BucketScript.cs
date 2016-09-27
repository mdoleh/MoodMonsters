using EggCatch;
using UnityEngine;

namespace AngryScene
{
    // Override for egg drop game to customize the behavior for the Angry Scene
    // Don't want to keep score
    public class BucketScript : PlayerScript
    {
        public Animator Lily;

        protected override void Update()
        {
            float moveInput = (Input.mousePosition.x / Screen.width) * 5f;
            
            Lily.SetFloat("Speed", moveInput > 0 ? 0.1f : -0.1f);

            transform.position = new Vector3(Mathf.Clamp(moveInput - 2.5f, -2.5f, 2.5f), transform.position.y, transform.position.z);
        }

        public override void UpdateScore(int value)
        {
            // do nothing
        }
    }
}