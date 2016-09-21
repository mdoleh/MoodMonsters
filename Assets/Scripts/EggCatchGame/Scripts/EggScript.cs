using UnityEngine;
using System.Collections;

namespace EggCatch
{
    // Makes the eggs "fall"
    public class EggScript : MonoBehaviour
    {
        private void Update()
        {
            float fallSpeed = 1.5f*Time.deltaTime;
            transform.position -= new Vector3(0, fallSpeed, 0);
        }
    }
}