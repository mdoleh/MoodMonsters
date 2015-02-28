using Globals;
using System.Collections;
using UnityEngine;

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
            GameObject.Find("DisablePanel").SetActive(false);
            gameObject.SetActive(false);
            Timeout.StartTimers();
        }
    }
}