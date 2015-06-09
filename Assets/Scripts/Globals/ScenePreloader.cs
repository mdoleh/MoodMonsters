using UnityEngine;

namespace Globals
{
    public class ScenePreloader : MonoBehaviour
    {
        void Start ()
	    {
	        Application.LoadLevelAsync(Scenes.NextSceneToLoad);
	    }
    }
}

