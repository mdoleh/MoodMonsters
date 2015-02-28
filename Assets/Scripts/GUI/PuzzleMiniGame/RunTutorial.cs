using Globals;
using System.Collections;
using UnityEngine;

namespace PuzzleMiniGame
{
    public class RunTutorial : MonoBehaviour
    {
        public Transform buttonDrag;

        public void PlayTutorial()
        {
            StartCoroutine(ShowDragging());
        }

        private IEnumerator ShowDragging()
        {
            var puzzlePieces = GameObject.Find("PuzzlePieces");
            var gridPanels = GameObject.Find("GridPanels");

            var piece = gridPanels.transform.GetChild(1).GetComponent<GridPanel>().CurrentPuzzlePiece.transform;
            piece.GetComponent<PuzzleDragDrop>().originalPosition = piece.localPosition;
            var gridPanel = gridPanels.transform.GetChild(2);

            piece.parent = buttonDrag.parent;
            // force buttonDrag to be on top of the puzzle piece
            buttonDrag.parent = null;
            buttonDrag.parent = piece.parent;
//            buttonDrag.localPosition = piece.localPosition;
            buttonDrag.parent.gameObject.SetActive(true);

            Utilities.PlayAudio(audio);
            yield return new WaitForSeconds(audio.clip.length);

            piece.parent = puzzlePieces.transform;
            piece.localPosition = gridPanel.localPosition;
            piece.GetComponent<PuzzleDragDrop>().SwapPieces(gridPanel.gameObject);
            piece.GetComponent<PuzzleDragDrop>().CheckPieceCorrect();

            GameObject.Find("DisablePanel").SetActive(false);
            gameObject.SetActive(false);
            Timeout.StartTimers();
        }
    }
}