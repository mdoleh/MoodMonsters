using UnityEngine;

namespace Globals
{
    public class ScenePreloader : MonoBehaviour
    {
        public static AsyncOperation CityLoad;
        public static GameObject City;

        private void Start ()
        {
            if (City != null) return;
            CityLoad = Application.LoadLevelAsync("SmallCity");
            CityLoad.allowSceneActivation = false;
	    }
    }
}

