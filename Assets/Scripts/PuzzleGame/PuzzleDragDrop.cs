using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Globals;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleDragDrop : MonoBehaviour {

    public Transform correctContainer;
    GameObject highlight;
    GameObject[] gridPanels;
    public bool disabled = false;
    private static List<GameObject> correctlyPlacedPieces = new List<GameObject>();

    public virtual void Awake()
    {
        gridPanels = GameObject.FindGameObjectsWithTag("GUI");
    }

    private void Start()
    {
        highlight = correctContainer.FindChild("Highlight").gameObject;
    }

    public void MovePanel()
    {
        if (disabled) return;
        Timeout.StopTimers();
        MoveToHierarchyBottom();
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // check if in range of container and highlight the container
        GameObject intersectingPanel = FindIntersectingPanel(gridPanels, gameObject);
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

    public virtual void PanelRelease()
    {
        if (disabled) return;
        if (RectsOverlap(correctContainer.GetComponent<RectTransform>(), GetComponent<RectTransform>()))
        {
            SubmitAnswer();
        }
        Timeout.StartTimers();
    }

    public virtual void SubmitAnswer() {
        highlight.SetActive(false);
        transform.position = correctContainer.transform.position;
        if (!correctlyPlacedPieces.Contains(gameObject)) correctlyPlacedPieces.Add(gameObject);
        if (correctlyPlacedPieces.Count == CreatePuzzlePieces.NUMBER_OF_PIECES)
        {
            var parent = transform.parent;
            parent.GetComponent<CreatePuzzlePieces>().sceneReset.TriggerCorrect(parent.GetComponent<AudioSource>(), parent.GetComponent<CreatePuzzlePieces>().sceneToLoadOnComplete);
        }
        MoveToHierarchyTop();
        disabled = true;
    }

    bool RectsOverlap(RectTransform r1, RectTransform r2)
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

    private void MoveToHierarchyTop()
    {
        var parent = transform.parent;
        for (var ii = 0; ii < parent.childCount; ++ii)
        {
            var child = parent.GetChild(ii);
            if (child == transform || child.GetComponent<PuzzleDragDrop>().disabled) continue;
            child.parent = null;
            child.parent = parent;
        }
    }
}
