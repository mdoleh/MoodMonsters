using System.Collections;
using UnityEngine;

namespace PreSceneMenus
{
    // Displays the first pre-scene question
    public class SceneStart : MonoBehaviour
    {
        private void Start()
        {
            GUIInitialization.Initialize();
            StartCoroutine(showCanvas());
        }

        private IEnumerator showCanvas()
        {
            yield return new WaitForSeconds(1f);
            GUIHelper.NextGUI(null, GUIHelper.GetCurrentGUI());
        }
    }
}