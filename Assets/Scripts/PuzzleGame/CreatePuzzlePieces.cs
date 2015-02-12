using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Globals;
using UnityEngine;
using UnityEngine.UI;

public class CreatePuzzlePieces : MonoBehaviour
{
    public Texture2D photo;
    public GameObject piecePrefab;
    public static int NUMBER_OF_PIECES;
    public SceneReset sceneReset;
    public string sceneToLoadOnComplete;
    public List<GameObject> gridPanels;

    private void Awake()
    {
//        gridPanels = GameObject.FindGameObjectsWithTag("GUI");
//        List<Object> pieces = GeneratePuzzlePieces(photo);
//        NUMBER_OF_PIECES = pieces.Count;
//        RandomizePiecePositions(pieces);
    }

    public List<Object> GeneratePuzzlePieces(int dimensions, string panelBase)
    {
        int width = (int)GetComponent<RectTransform>().rect.width / dimensions;
        int height = (int)GetComponent<RectTransform>().rect.height / dimensions;
        TextureScale.Bilinear(photo, width * dimensions, height * dimensions);
        photo.Apply();

        Color[] imageData;
        List<Object> pieces = new List<Object>();
        Object piece;
        int panelNumber = 1;

        for (int y = 0; y < dimensions; ++y)
        {
            for (int x = 0; x < dimensions; ++x)
            {
                piece = Instantiate(piecePrefab);
                ((GameObject)piece).transform.parent = transform;
                imageData = photo.GetPixels(x * width, y * height, width, height);
                var texture = new Texture2D(width, height);
                texture.SetPixels(imageData);
                texture.Apply();

                ((GameObject)piece).GetComponent<RawImage>().texture = texture;
                ((GameObject)piece).GetComponent<RawImage>().SetNativeSize();
                ((GameObject)piece).GetComponent<PuzzleDragDrop>().correctContainer = GetGridPanelByName(gridPanels, panelBase + panelNumber++).transform;
                pieces.Add(piece);
            }
        }
        return pieces;
    }

    private GameObject GetGridPanelByName(List<GameObject> gridPanels, string name)
    {
        return gridPanels.FirstOrDefault(gridPanel => gridPanel.name.Equals(name));
    }

    public void RandomizePiecePositions(List<Object> pieces)
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
