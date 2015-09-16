using System.Collections;
using UnityEngine;

namespace SadScene
{
    public class ConeDisappear : MonoBehaviour
    {
        private bool shouldSink = false;
        private ConeManager coneManager;

        private void Start()
        {
            coneManager = transform.parent.GetComponent<ConeManager>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.name.ToLower().Equals("soccerball") && !shouldSink)
            {
                // not the first cone then play audio
                if (!gameObject.name.Contains("1"))
                    Utilities.PlayRandomAudio(transform.parent.FindChild("Audio").GetComponentsInChildren<AudioSource>());
                shouldSink = true;
                StartCoroutine(HideObject());
            }
        }

        private IEnumerator HideObject()
        {
            yield return new WaitForSeconds(1f);
            GetComponent<BoxCollider>().enabled = false;
            coneManager.NextInSequence();
            coneManager.RandomizePositionZ();
            yield return new WaitForSeconds(1f);
            gameObject.SetActive(false);
        }
    }
}