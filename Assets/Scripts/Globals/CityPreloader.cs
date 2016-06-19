﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Globals
{
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