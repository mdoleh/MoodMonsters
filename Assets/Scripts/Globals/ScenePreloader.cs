using UnityEngine;

namespace Globals
{
    public class ScenePreloader : MonoBehaviour
    {
        public static AsyncOperation CityLoad;
        public static GameObject City;

        private void Start ()
        {
            CityLoad = Application.LoadLevelAsync(City == null ? "SmallCity" : "Empty");
            CityLoad.allowSceneActivation = false;
	    }
    }
}

