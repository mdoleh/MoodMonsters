using System.Collections;
using UnityEngine;

namespace AngryScene
{
    // For scene resets, initializes the scene and animations appropriately
    public class TakeItemActionsMenu : TakeItem
    {
        private void Start()
        {
            StartCoroutine(StartUsingIPadDelayed());
        }

        private IEnumerator StartUsingIPadDelayed()
        {
            yield return new WaitForSeconds(2f);
            anim.SetBool("IsUsingIPad", true);
            other.SetTrigger("IsAngry");
            GUIInitialization.Initialize();
            GUIHelper.NextGUI(null, GUIHelper.GetCurrentGUI());
        }
    }
}