using System.Linq;
using UnityEngine;

namespace BlendsScene
{
    // Used on parent model to control when it walks into frame
    // Also triggers the dialogue between the characters to start
    public class WalkForward : MonoBehaviour
    {
        public Animator[] children;

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
                    children.ToList().ForEach(x => x.SetTrigger("Idle"));
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