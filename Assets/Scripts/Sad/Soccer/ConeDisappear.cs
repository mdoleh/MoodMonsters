using System.Collections;
using UnityEngine;

namespace SadScene
{
    public class ConeDisappear : MonoBehaviour
    {
        private bool shouldSink = false;
        private float alpha = 1.0f;
        private ConeManager manager;

        private void Start()
        {
            manager = transform.parent.GetComponent<ConeManager>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.name.ToLower().Equals("soccerball") && !shouldSink)
            {
                shouldSink = true;
                StartCoroutine(HideObject());
            }
        }

        private IEnumerator HideObject()
        {
            yield return new WaitForSeconds(1f);
            GetComponent<BoxCollider>().enabled = false;
            manager.NextCone();
            yield return new WaitForSeconds(1f);
            gameObject.SetActive(false);
        }
    }
}