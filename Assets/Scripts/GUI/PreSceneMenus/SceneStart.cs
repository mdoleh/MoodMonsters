using UnityEngine;

namespace PreSceneMenus
{
    public class SceneStart : MonoBehaviour
    {
        public DelayShowCanvas canvasToShow;

        private void Start()
        {
            GUIInitialization.Initialize();
            StartCoroutine(canvasToShow.ShowCanvas());
        }
    }
}