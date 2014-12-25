using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class RunAway : ActionBase
    {

        Animator anim;
        bool run = false;
        float rotation;

        public void Awake()
        {
            anim = GetComponent<Animator>();
        }

        void Update() {
            base.Update();
            if (run)
            {
                float move = Time.deltaTime * 1.5f;
                transform.position = new Vector3(transform.position.x - move, transform.position.y, transform.position.z);
            }
            if (anim.GetBool("IsTurningSad") && Mathf.Abs(transform.rotation.eulerAngles.y - rotation) >= 180)
            {
                anim.SetBool("IsTurningSad", false);
                StartRunningAway();
            }
        }

        public void StartTurning()
        {
            rotation = transform.rotation.eulerAngles.y;
            anim.SetBool("IsTurningSad", true);
        }

        public void StartRunningAway()
        {
            startTimer = true;
            eventTrigger = true;
            anim.SetTrigger("IsHiding");
            run = true;
        }

        public void UpdateRotationHide() {
//            transform.rotation = Quaternion.Euler(new Vector3(0, -90.0f, 0));
            //transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y - 85.0f, 0));
            transform.Rotate(new Vector3(0, -90.0f, 0));
        }
    }
}