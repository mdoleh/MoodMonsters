using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Used to load shared assets stored in scenes into the current scene
// (ex: End Credits)
public class Loader : MonoBehaviour
{
    public string SceneToLoad;

    private void Start()
    {
        SceneManager.LoadSceneAsync(SceneToLoad, LoadSceneMode.Additive);
    }
}