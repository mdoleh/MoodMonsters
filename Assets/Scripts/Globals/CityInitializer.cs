using System.Collections;
using UnityEngine;

namespace Globals
{
    public class CityInitializer : MonoBehaviour
    {
        public static GameObject City;

        void Start()
        {
            DontDestroyOnLoad(gameObject);
            City = gameObject;
            StartCoroutine(DelayDisable());
        }

        private IEnumerator DelayDisable()
        {
            yield return new WaitForSeconds(1f);
            gameObject.SetActive(false);
        }
    }
}