using UnityEngine;
using System.Collections;

public class DelayShowCanvas : MonoBehaviour
{
    public IEnumerator ShowCanvas()
    {
        yield return new WaitForSeconds(1f);
        GUIHelper.NextGUI(null, GUIHelper.GetCurrentGUI());
    }
}
