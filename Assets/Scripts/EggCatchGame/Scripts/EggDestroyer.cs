﻿using UnityEngine;
using System.Collections;

namespace EggCatch
{
    // Cleans up missed eggs
    public class EggDestroyer : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            //Destroy this gameobject (and all attached components)
            Destroy(other.transform.parent.gameObject);
        }
    }
}