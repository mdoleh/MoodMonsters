using UnityEngine;

namespace Globals
{
    public class ScenePreloader : MonoBehaviour
    {
        public static AsyncOperation CityLoad;

        private void Start ()
	    {
            CityLoad = Application.LoadLevelAsync("SmallCity");
            CityLoad.allowSceneActivation = false;
	    }
    }
}

