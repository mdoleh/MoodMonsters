using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Globals;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzleMiniGame
{
    public class CreatePuzzlePieces : MonoBehaviour
    {
        public Texture2D photo;
        public GameObject piecePrefab;
        public SceneReset sceneReset;
        public string sceneToLoadOnComplete;
        public RunTutorial tutorialCanvas;

        public List<GameObject> GeneratePuzzlePieces(List<GameObject> gridPanels, int dimensions, string panelBase,
            int width, int height)
        {
            TextureScale.Bilinear(photo, width*dimensions, height*dimensions);
            photo.Apply();

            Color[] imageData;
            List<GameObject> pieces = new List<GameObject>();
            GameObject piece;
            int panelNumber = 1;

            for (int y = 0; y < dimensions; ++y)
            {
                for (int x = 0; x < dimensions; ++x)
                {
                    piece = (GameObject) Instantiate(piecePrefab);
                    piece.transform.parent = transform;
                    imageData = photo.GetPixels(x*width, y*height, width, height);
                    var texture = new Texture2D(width, height);
                    texture.SetPixels(imageData);
                    texture.Apply();

                    piece.GetComponent<RawImage>().texture = texture;
                    piece.GetComponent<RawImage>().SetNativeSize();
                    piece.GetComponent<PuzzleDragDrop>().correctContainer =
                        GetGridPanelByName(gridPanels, panelBase + panelNumber++).transform;
                    pieces.Add(piece);
                }
            }
            return pieces;
        }

        private GameObject GetGridPanelByName(List<GameObject> gridPanels, string name)
        {
            return gridPanels.FirstOrDefault(gridPanel => gridPanel.name.Equals(name));
        }

        private void ArrangePiecesWithGrids(List<GameObject> pieces)
        {
            foreach (var piece in pieces)
            {
                piece.transform.localPosition = piece.GetComponent<PuzzleDragDrop>().correctContainer.localPosition;
            }
        }

        public void RandomizePiecePositions(List<GameObject> pieces, AudioSource shuffleSound)
        {
            ArrangePiecesWithGrids(pieces);
            StartCoroutine(ShufflePositions(pieces, shuffleSound));
        }

        private IEnumerator ShufflePositions(List<GameObject> pieces, AudioSource shuffleSound)
        {
            yield return new WaitForSeconds(3.0f);
            var piecesMutable = new List<GameObject>(pieces);
            while (piecesMutable.Count > 0)
            {
                yield return new WaitForSeconds(0.5f);
                var first = piecesMutable[Random.Range(0, piecesMutable.Count)];
                piecesMutable.Remove(first);
                if (piecesMutable.Count == 0)
                {
                    first.GetComponent<PuzzleDragDrop>().correctContainer.GetComponent<GridPanel>().CurrentPuzzlePiece = first;
                    first.transform.localPosition = first.GetComponent<PuzzleDragDrop>().correctContainer.localPosition;
                    continue;
                };
                var second = piecesMutable[Random.Range(0, piecesMutable.Count)];
                piecesMutable.Remove(second);

                first.transform.localPosition = second.GetComponent<PuzzleDragDrop>().correctContainer.localPosition;
                second.transform.localPosition = first.GetComponent<PuzzleDragDrop>().correctContainer.localPosition;
                first.GetComponent<PuzzleDragDrop>().correctContainer.GetComponent<GridPanel>().CurrentPuzzlePiece = second;
                second.GetComponent<PuzzleDragDrop>().correctContainer.GetComponent<GridPanel>().CurrentPuzzlePiece = first;
                Utilities.PlayAudio(shuffleSound);
            }

            yield return new WaitForSeconds(shuffleSound.clip.length);
            DisableCorrectlyPlacedPieces(pieces);
            GameObject.Find("DisablePanel").SetActive(false);
            Utilities.PlayAudio(transform.parent.audio);
            Timeout.SetRepeatAudio(transform.parent.audio);
            yield return new WaitForSeconds(transform.parent.audio.clip.length);
            tutorialCanvas.PlayTutorial();
        }

        private void DisableCorrectlyPlacedPieces(List<GameObject> pieces)
        {
            foreach (var piece in pieces)
            {
                piece.GetComponent<PuzzleDragDrop>().CheckPieceCorrect();
            }
        }
    }
}