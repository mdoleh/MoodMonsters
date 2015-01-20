using UnityEngine;
using System.Collections;

namespace PuzzleTutorial
{
    public class RunTutorial : MonoBehaviour
    {
        public Transform[] markers; 

        // Use this for initialization
        private void Start()
        {
            GetComponent<GUIManager>().enabled = false;
            StartCoroutine(ShowMarkers());
            StartCoroutine(ShowMarkersExtra());
        }

        IEnumerator ShowMarkers()
        {
            yield return new WaitForSeconds(1);

            //Scale up the markers
            StartCoroutine(ScaleObject(markers[0], Vector2.one, 0.25f, 0));
            StartCoroutine(ScaleObject(markers[1], Vector2.one, 0.25f, 0));
            Utilities.PlayAudio(audio);

            yield return new WaitForSeconds(audio != null ? audio.clip.length : 2);

            //Scale down the markers to zero
            markers[0].localScale = Vector2.zero;
            markers[1].localScale = Vector2.zero;
        }

        IEnumerator ShowMarkersExtra()
        {
            if (markers.Length > 3)
            {
                yield return new WaitForSeconds(2);

                for (int i = 3; i < markers.Length; ++i)
                {
                    yield return new WaitForSeconds(1);

                    //Scale up the markers
                    StartCoroutine(ScaleObject(markers[i], Vector2.one, 0.25f, 0));
                    var markerAudio = markers[i].GetComponent<AudioSource>();
                    var action = markers[i].GetComponent<TutorialAction>();
                    if (action != null) action.DoAction();
                    Utilities.PlayAudio(markerAudio);

                    yield return new WaitForSeconds(markerAudio.clip.length);

                    //Scale down the markers to zero
                    markers[i].localScale = Vector2.zero;
                }
            }
            GetComponent<GUIManager>().enabled = true;
            enabled = false;
        }

        IEnumerator ScaleObject(Transform obj, Vector2 end, float time, float delay)
        {
            yield return new WaitForSeconds(delay);

            Vector2 originalScale = obj.localScale;

            float rate = 1.0f / time;
            float i = 0.0f;

            while (i < 1.0f)
            {
                i += Time.deltaTime * rate;
                obj.localScale = Vector2.Lerp(originalScale, end, i);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}