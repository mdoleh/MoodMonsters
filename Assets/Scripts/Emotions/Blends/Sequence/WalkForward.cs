using UnityEngine;

namespace BlendsScene
{
    public class WalkForward : MonoBehaviour
    {
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (anim.GetBool("Walk"))
            {
                changePosition(1f);
                if (transform.position.z <= 143.637f)
                {
                    anim.SetBool("Walk", false);
                    GetComponent<DialogueParent>().ExplainMoving();
                }
            }
        }

        private void changePosition(float speed)
        {
            float move = Time.deltaTime * speed;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - move);
        }
    }
}