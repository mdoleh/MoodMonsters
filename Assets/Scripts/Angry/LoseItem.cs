using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class LoseItem : MonoBehaviour
    {
        Animator anim;

        public void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void StartLosingItem() {
            anim.SetTrigger("IsLosingIPad");
        }
    }
}