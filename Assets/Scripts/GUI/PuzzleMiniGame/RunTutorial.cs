using UnityEngine;
using System.Collections;
using Globals;
using UnityEditorInternal;

namespace PuzzleMiniGame
{
    public class RunTutorial : MonoBehaviour
    {
        public void PlayTutorial()
        {
            StartCoroutine(ShowDragging());
        }

        private IEnumerator ShowDragging()
        {
            var buttonDrag = transform.Find("ButtonDrag");
            buttonDrag.parent = GameObject.Find("PuzzlePieces").transform;
            buttonDrag.gameObject.SetActive(true);
            Utilities.PlayAudio(audio);
            yield return new WaitForSeconds(audio.clip.length);
            buttonDrag.parent = transform;
            gameObject.SetActive(false);
            Timeout.StartTimers();
        }
    }
}