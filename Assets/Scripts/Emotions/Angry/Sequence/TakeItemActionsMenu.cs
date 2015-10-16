using UnityEngine;
using System.Collections;
using Globals;

namespace AngryScene
{
    public class TakeItemActionsMenu : TakeItem
    {
        private void Start()
        {
            StartCoroutine(StartUsingIPad());
        }

        private IEnumerator StartUsingIPad()
        {
            yield return new WaitForSeconds(2f);
            anim.SetBool("IsUsingIPad", true);
            other.SetTrigger("IsAngry");
            GUIHelper.NextGUI(null, GUIHelper.GetCurrentGUI());
        }
    }
}