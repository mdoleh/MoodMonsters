using UnityEngine;
using System.Collections;

namespace ScaredScene
{
    public class TemperTantrum : ActionBase
    {
        public AudioSource tantrumDialogue;
        private Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
    }
}