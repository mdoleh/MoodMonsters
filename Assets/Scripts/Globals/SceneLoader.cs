using Globals;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        ScenePreloader.City = gameObject;
    }

	void Start () 
    {
        if (!string.IsNullOrEmpty(Scenes.NextSceneToLoad)) Application.LoadLevelAdditive(Scenes.NextSceneToLoad);
	}
}
