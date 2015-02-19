using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Globals;
using UnityEngine;
using UnityEngine.UI;

namespace PuzzleMiniGame
{
    public class PuzzleDragDrop : MonoBehaviour
    {

        public Transform correctContainer;
        GameObject highlight;
        GameObject[] gridPanels;
        private Vector3 originalPosition;
        private GameObject intersectingPanel;
        public bool disabled = false;

        private void Awake()
        {
            gridPanels = GameObject.FindGameObjectsWithTag("GUI");
        }

        private void Start()
        {
            highlight = correctContainer.FindChild("Highlight").gameObject;
        }

        public void ClickPanel()
        {
            Timeout.StartTimers();
            originalPosition = transform.localPosition;
            Timeout.StartTimers();
        }

        public void MovePanel()
        {
            if (disabled) return;
            Timeout.StopTimers();
            MoveToHierarchyBottom();
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            // check if in range of container and highlight the container
            intersectingPanel = FindIntersectingPanel(gridPanels, gameObject);
            if (intersectingPanel != null)
            {
                ResetAllPanelColors(gridPanels);
                intersectingPanel.transform.FindChild("Highlight").gameObject.SetActive(true);
            }
            else
            {
                ResetAllPanelColors(gridPanels);
            }
        }

        public void PanelRelease()
        {
            if (disabled) return;
            highlight.SetActive(false);
            if (intersectingPanel == null || intersectingPanel.GetComponent<GridPanel>().CurrentPuzzlePiece.GetComponent<PuzzleDragDrop>().disabled)
            {
                transform.localPosition = originalPosition;
            }
            else
            {
                SubmitAnswer(intersectingPanel, intersectingPanel == correctContainer.gameObject);
            }
            Timeout.StartTimers();
        }

        public void CheckPieceCorrect()
        {
            if (RectsOverlap(correctContainer.GetComponent<RectTransform>(), gameObject.GetComponent<RectTransform>()))
            {
                correctContainer.GetComponent<GridPanel>().CurrentPuzzlePiece = gameObject;
                disabled = true;
            }
        }

        private void SubmitAnswer(GameObject intersectingPanel, bool isCorrectContainer)
        {
            if (intersectingPanel == null) return;
            transform.localPosition = intersectingPanel.transform.localPosition;
            if (intersectingPanel.GetComponent<GridPanel>().CurrentPuzzlePiece == gameObject) return;
            intersectingPanel.GetComponent<GridPanel>().CurrentPuzzlePiece.transform.localPosition = originalPosition;
            intersectingPanel.GetComponent<GridPanel>().CurrentPuzzlePiece.GetComponent<PuzzleDragDrop>().CheckPieceCorrect();
            intersectingPanel.GetComponent<GridPanel>().CurrentPuzzlePiece = gameObject;
            if (!isCorrectContainer) return;
            disabled = true;
            if (AllPiecesInCorrectPlaces())
            {
                var parent = transform.parent;
                parent.GetComponent<CreatePuzzlePieces>().sceneReset.TriggerCorrect(parent.GetComponent<AudioSource>(), parent.GetComponent<CreatePuzzlePieces>().sceneToLoadOnComplete);
            }
        }

        private bool AllPiecesInCorrectPlaces()
        {
            return gridPanels.All(gridPanel => gridPanel.GetComponent<GridPanel>().CurrentPuzzlePiece.GetComponent<PuzzleDragDrop>().disabled);
        }

        private bool RectsOverlap(RectTransform r1, RectTransform r2)
        {
            bool widthOverlap = (r1.position.x >= r2.position.x && r1.position.x <= r2.position.x + r2.rect.width * 0.4 * r2.localScale.x) ||
                                (r2.position.x >= r1.position.x && r2.position.x <= r1.position.x + r1.rect.width * 0.4 * r1.localScale.x);

            bool heightOverlap = (r1.position.y >= r2.position.y && r1.position.y <= r2.position.y + r2.rect.height * 0.4 * r2.localScale.y) ||
                                (r2.position.y >= r1.position.y && r2.position.y <= r1.position.y + r1.rect.height * 0.4 * r1.localScale.y);

            return (widthOverlap && heightOverlap);
        }

        private GameObject FindIntersectingPanel(GameObject[] panels, GameObject current)
        {
            return panels.FirstOrDefault(panel => RectsOverlap(current.GetComponent<RectTransform>(), panel.GetComponent<RectTransform>()));
        }

        private void ResetAllPanelColors(GameObject[] panels)
        {
            foreach (var panel in panels)
            {
                panel.transform.FindChild("Highlight").gameObject.SetActive(false);
            }
        }

        private void MoveToHierarchyBottom()
        {
            var parent = transform.parent;
            transform.parent = null;
            transform.parent = parent;
        }
    }
}