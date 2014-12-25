using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class PuzzleDragDrop : MonoBehaviour {

    public Transform correctContainer;
    Color oldColor;
    GameObject[] gridPanels;
    private bool disabled = false;

    public virtual void Awake()
    {
        gridPanels = GameObject.FindGameObjectsWithTag("GUI");
        oldColor = gridPanels[0].GetComponent<Image>().color;
    }

    public void MovePanel()
    {
        if (disabled) return;
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // check if in range of container and highlight the container
        GameObject intersectingPanel = FindIntersectingPanel(gridPanels, gameObject);
        if (intersectingPanel != null)
        {
            ResetAllPanelColors(gridPanels, oldColor);
            intersectingPanel.GetComponent<Image>().color = Color.red;
        }
        else
        {
            ResetAllPanelColors(gridPanels, oldColor);
        }
    }

    public virtual void PanelRelease()
    {
        if (RectsOverlap(correctContainer.GetComponent<RectTransform>(), GetComponent<RectTransform>()))
        {
            SubmitAnswer();
        }
    }

    public virtual void SubmitAnswer() {
        correctContainer.GetComponent<Image>().color = oldColor;
        transform.position = correctContainer.transform.position;
        disabled = true;
    }

    bool RectsOverlap(RectTransform r1, RectTransform r2)
    {
        bool widthOverlap = (r1.position.x >= r2.position.x && r1.position.x <= r2.position.x + r2.rect.width * 0.4) ||
                            (r2.position.x >= r1.position.x && r2.position.x <= r1.position.x + r1.rect.width * 0.4);

        bool heightOverlap = (r1.position.y >= r2.position.y && r1.position.y <= r2.position.y + r2.rect.height * 0.4) ||
                            (r2.position.y >= r1.position.y && r2.position.y <= r1.position.y + r1.rect.height * 0.4);
                       
        return (widthOverlap && heightOverlap);
    }

    private GameObject FindIntersectingPanel(GameObject[] panels, GameObject current)
    {
        return panels.FirstOrDefault(panel => RectsOverlap(current.GetComponent<RectTransform>(), panel.GetComponent<RectTransform>()));
    }

    private void ResetAllPanelColors(GameObject[] panels, Color color)
    {
        foreach (var panel in panels)
        {
            panel.GetComponent<Image>().color = color;
        }
    }
}
