using System.Collections;
using UnityEngine;

namespace HappyScene
{
    public class SkeeballCharacterMovementActionsMenu : SkeeballCharacterMovement
    {
        protected override void Start()
        {
            base.Start();
            GUIInitialization.Initialize();
            StartCoroutine(ShowActionsMenu());
        }

        protected IEnumerator ShowActionsMenu()
        {
            yield return new WaitForSeconds(2f);
            GUIHelper.NextGUI(null, GUIHelper.GetCurrentGUI());
        }
    }
}