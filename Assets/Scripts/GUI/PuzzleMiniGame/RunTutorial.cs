using Globals;
using System.Collections;
using UnityEngine;

namespace PuzzleMiniGame
{
    public class RunTutorial : MonoBehaviour
    {
        public Transform buttonDrag;
        private bool showDragging = false;
        private Transform piece;
        private Transform gridPanel;
        private GameObject puzzlePieces;
        private GameObject gridPanels;

        public void PlayTutorial()
        {
            puzzlePieces = GameObject.Find("PuzzlePieces");
            gridPanels = GameObject.Find("GridPanels");

            piece = gridPanels.transform.GetChild(0).GetComponent<GridPanel>().CurrentPuzzlePiece.transform;
            piece.GetComponent<PuzzleDragDrop>().originalPosition = piece.localPosition;
            gridPanel = gridPanels.transform.GetChild(1);

            StartCoroutine(ShowDragging());
        }

        private IEnumerator ShowDragging()
        {
            piece.parent = buttonDrag.parent;
            // force buttonDrag to be on top of the puzzle piece
            buttonDrag.parent = null;
            buttonDrag.parent = piece.parent;
            buttonDrag.localPosition = new Vector3(piece.localPosition.x, buttonDrag.localPosition.y);
            buttonDrag.gameObject.SetActive(true);

            showDragging = true;
            Utilities.PlayAudio(audio);
            yield return new WaitForSeconds(audio.clip.length);
            showDragging = false;

            piece.parent = puzzlePieces.transform;
            piece.localPosition = gridPanel.localPosition;
            piece.GetComponent<PuzzleDragDrop>().SwapPieces(gridPanel.gameObject);
            piece.GetComponent<PuzzleDragDrop>().CheckPieceCorrect();

            GameObject.Find("DisablePanel").SetActive(false);
            gameObject.SetActive(false);
            Timeout.StartTimers();
        }

        private void Update()
        {
            if (showDragging)
            {
                piece.localPosition = new Vector3(buttonDrag.localPosition.x, piece.localPosition.y);
            }
        }
    }
}