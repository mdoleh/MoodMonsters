using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class RunAway : MonoBehaviour
    {

        Animator anim;
        bool run = false;
        float rotation;

        public void Awake()
        {
            anim = GetComponent<Animator>();
        }

        void Update() {
            if (run)
            {
                float move = Time.deltaTime * 1.5f;
                transform.position = new Vector3(transform.position.x - move, transform.position.y, transform.position.z);
            }
            if (anim.GetBool("IsTurning") && Mathf.Abs(transform.rotation.eulerAngles.y - rotation) >= 180)
            {
                anim.SetBool("IsTurning", false);
                StartRunningAway();
            }
        }

        public void StartTurning()
        {
            rotation = transform.rotation.y;
            anim.SetBool("IsTurning", true);
        }

        public void StartRunningAway()
        {
            anim.SetTrigger("IsHiding");
            run = true;
        }

        public void UpdateRotation() {
            transform.rotation = Quaternion.Euler(new Vector3(0, -90.0f, 0));
            //transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y - 85.0f, 0));
            //transform.Rotate(new Vector3(0, -90.0f, 0));
        }
    }
}