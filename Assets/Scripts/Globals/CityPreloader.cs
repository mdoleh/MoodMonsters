﻿using UnityEngine;

namespace Globals
{
    public class CityPreloader : MonoBehaviour
    {
        private void Start()
        {
            if (CityInitializer.City == null)
                Application.LoadLevelAdditive("SmallCity");
            else
            {
                CityInitializer.City.SetActive(false);
            }
        }
    }
}