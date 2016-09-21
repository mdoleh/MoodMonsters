using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Globals
{
    // Loads the main city back drop into the world
    // This gets executed on the Title Screen
    public class CityPreloader : MonoBehaviour
    {
        private void Start()
        {
            if (CityInitializer.City == null)
                SceneManager.LoadSceneAsync("SmallCity", LoadSceneMode.Additive);
            else
            {
                CityInitializer.City.SetActive(false);
            }
        }
    }
}