using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class CheckFaceAndBody : CorrectActionBase
    {
        protected override void AfterDialogue()
        {
            GUIHelper.NextGUI();
        }
    }
}