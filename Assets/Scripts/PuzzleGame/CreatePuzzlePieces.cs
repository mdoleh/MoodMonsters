using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using UnityEngine.UI;

public class CreatePuzzlePieces : MonoBehaviour
{
    public Texture2D photo;
    public GameObject piecePrefab;
    public static int NUMBER_OF_PIECES;
    public SceneReset sceneReset;
    public string sceneToLoadOnComplete;
    private GameObject[] gridPanels;

    private const string PANEL_BASE = "GridPanel";
    private const int DIMENSIONS = 3;

    public virtual void Awake()
    {
        gridPanels = GameObject.FindGameObjectsWithTag("GUI");
        List<Object> pieces = GeneratePuzzlePieces(photo);
        NUMBER_OF_PIECES = pieces.Count;
        RandomizePiecePositions(pieces);
    }

    private List<Object> GeneratePuzzlePieces(Texture2D photo)
    {
        int width = (int)GetComponent<RectTransform>().rect.width / DIMENSIONS;
        int height = (int)GetComponent<RectTransform>().rect.height / DIMENSIONS;
        TextureScale.Bilinear(photo, width * DIMENSIONS, height * DIMENSIONS);
        photo.Apply();

        Color[] imageData;
        List<Object> pieces = new List<Object>();
        Object piece;
        int panelNumber = 1;

        for (int y = 0; y < DIMENSIONS; ++y)
        {
            for (int x = 0; x < DIMENSIONS; ++x)
            {
                piece = Instantiate(piecePrefab);
                ((GameObject)piece).transform.parent = transform;
                imageData = photo.GetPixels(x * width, y * height, width, height);
                var texture = new Texture2D(width, height);
                texture.SetPixels(imageData);
                texture.Apply();

                ((GameObject)piece).GetComponent<RawImage>().texture = texture;
                ((GameObject)piece).GetComponent<RawImage>().SetNativeSize();
                ((GameObject)piece).GetComponent<PuzzleDragDrop>().correctContainer = GetGridPanelByName(gridPanels, PANEL_BASE + panelNumber++).transform;
                pieces.Add(piece);
            }
        }
        return pieces;
    }

    private GameObject GetGridPanelByName(GameObject[] gridPanels, string name)
    {
        return gridPanels.FirstOrDefault(gridPanel => gridPanel.name.Equals(name));
    }

    private void RandomizePiecePositions(List<Object> pieces)
    {
        float max = ((GameObject)pieces[0]).transform.parent.GetComponent<RectTransform>().rect.width - ((GameObject) pieces[0]).GetComponent<RectTransform>().rect.width;
        max /= 2;
        float min = max*-1;
        foreach (var piece in pieces)
        {
            ((GameObject)piece).transform.localPosition = new Vector3(Random.Range(min, max), Random.Range(min, max), 0f);
        }
    }
}
