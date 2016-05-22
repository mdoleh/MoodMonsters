using System.Collections;
using UnityEngine;

namespace PreSceneMenus
{
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