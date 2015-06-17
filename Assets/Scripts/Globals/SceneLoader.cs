using Globals;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

	void Start () 
    {
        Application.LoadLevelAdditive(Scenes.NextSceneToLoad);
        Scenes.NextSceneToLoad = string.Empty;
	}
}
