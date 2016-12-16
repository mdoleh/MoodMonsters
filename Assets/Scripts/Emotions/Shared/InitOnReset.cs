using UnityEngine;
using System.Collections;
using System.Linq;

// Covers common behavior among all scene resets
// Only used in ActionsMenu scenes
public class InitOnReset : MonoBehaviour
{
    protected virtual void Start()
    {
        // if the current question is a parent question then
        // we should show the appropriate PASS letters
        var passReminder = GUIHelper.GetCurrentGUI().transform.Find("PASSReminder");
        if (passReminder != null)
        {
            var passLetters = passReminder.GetComponentsInChildren<Transform>().ToList();
            // remove PASSReminder from the list of letters
            passLetters.Remove(passLetters.First(x => x.name.Equals(passReminder.name)));
            var passCanvas = GameObject.Find("PASSCanvas").transform;
            passLetters.ForEach(x => passCanvas.FindChild(x.name).gameObject.SetActive(true));
        }
        StartCoroutine(ShowActionsMenu());
    }

    protected IEnumerator ShowActionsMenu()
    {
        yield return new WaitForSeconds(2f);
        GUIHelper.NextGUI(null, GUIHelper.GetCurrentGUI());
        gameObject.SetActive(false);
    }
}
