using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public string SceneToLoad;

    private void Start()
    {
        SceneManager.LoadSceneAsync(SceneToLoad, LoadSceneMode.Additive);
    }
}