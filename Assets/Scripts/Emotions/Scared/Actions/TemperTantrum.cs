using UnityEngine;
using System.Collections;

namespace ScaredScene
{
    // Incorrect option choice for both Emotion and Situation Actions
    public class TemperTantrum : IncorrectActionBase
    {
        protected override void DialogueAnimation()
        {
            base.DialogueAnimation();
            transform.Find("CameraFollow").gameObject.SetActive(false);
            anim.SetTrigger("Tantrum");
        }
    }
}