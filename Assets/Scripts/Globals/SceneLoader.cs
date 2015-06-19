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
        Application.LoadLevelAdditive(Scenes.NextSceneToLoad);
	}
}
