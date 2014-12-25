using UnityEngine;
using System.Collections;
using System.Net.Mime;
using UnityEngine.UI;

public class CreatePuzzlePieces : MonoBehaviour
{
    public Texture2D photo;
    public GameObject piecePrefab;
    private GameObject[] gridPanels;

    public virtual void Awake()
    {
        gridPanels = GameObject.FindGameObjectsWithTag("GUI");
        GeneratePuzzlePieces(photo);
    }

    private void GeneratePuzzlePieces(Texture2D photo)
    {
        int width = (int)GetComponent<RectTransform>().rect.width / 3;
        int height = (int)GetComponent<RectTransform>().rect.height / 3;

        var imageData = photo.GetPixels(0, 0, width, height);
        var piece = Instantiate(piecePrefab);
        ((GameObject)piece).transform.parent = transform;
        var texture = new Texture2D(width, height);
        texture.SetPixels(imageData);
        texture.Apply();
        ((GameObject)piece).GetComponent<RawImage>().texture = texture;
        ((GameObject)piece).GetComponent<PuzzleDragDrop>().correctContainer = gridPanels[0].transform;
    }
}
