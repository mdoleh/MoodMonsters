using System.Collections;
using UnityEngine;

namespace Globals
{
    public class CityPreloader : MonoBehaviour
    {
        private void Start()
        {
            if (CityInitializer.City == null)
                StartCoroutine(LoadCity());
            else
            {
                CityInitializer.City.SetActive(false);
            }
        }

        private IEnumerator LoadCity()
        {
            yield return new WaitForSeconds(5f);
            Application.LoadLevelAdditiveAsync("SmallCity");
        }
    }
}