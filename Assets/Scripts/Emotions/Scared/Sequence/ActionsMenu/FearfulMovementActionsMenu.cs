using System.Collections;
using System.Linq;
using Globals;
using UnityEngine;

namespace ScaredScene
{
    public class FearfulMovementActionsMenu : FearfulMovement
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
            StartCoroutine(ShowActionsMenu());
            waitingForScarlet = false;
        }

        private IEnumerator ShowActionsMenu()
        {
            yield return new WaitForSeconds(2f);
            var previousCanvas = GUIHelper.GetPreviousGUI("ActionsCanvas");
            previousCanvas.GetComponent<Canvas>().enabled = true;
            GUIHelper.NextGUI();
        }
    }
}