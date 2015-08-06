using System.Collections;
using System.Linq;
using Globals;
using UnityEngine;

namespace ScaredScene
{
    public class FearfulMovementParentActionsMenu : FearfulMovement
    {
        protected override void Start()
        {
            base.Start();
            GUIInitialization.Initialize();
            if (GameFlags.AdultIsPresent)
            {
                parentCharacters.ToList()
                    .First(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()))
                    .SetActive(true);
            }
            StartCoroutine(ShowParentActionsMenu());
            waitingForScarlet = false;
        }

        private IEnumerator ShowParentActionsMenu()
        {
            yield return new WaitForSeconds(2f);
            var previousCanvas = GUIHelper.GetPreviousGUI("ParentActionsCanvas" + GameFlags.ParentGender);
            previousCanvas.GetComponent<Canvas>().enabled = true;
            GUIHelper.NextGUI();
        }
    }
}