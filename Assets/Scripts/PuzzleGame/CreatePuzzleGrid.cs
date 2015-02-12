using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Globals;

public class CreatePuzzleGrid : MonoBehaviour
{
    public GameObject gridPrefab;
    public CreatePuzzlePieces puzzlePieceGenerator;
    public const string PANEL_BASE = "GridPanel";
    public const int DIMENSIONS = 4;

    private const int X_LOWER_BOUND = -124;
    private const int Y_LOWER_BOUND = -127;
    private const float MAX_WIDTH = 399;
    private const float MAX_HEIGHT = 399;

    void Awake()
    {
        var gridPanels = GenerateGridPanels(DIMENSIONS, PANEL_BASE);
        CreatePuzzlePieces.NUMBER_OF_PIECES = gridPanels.Count;
        puzzlePieceGenerator.gridPanels = gridPanels;
        puzzlePieceGenerator.RandomizePiecePositions(puzzlePieceGenerator.GeneratePuzzlePieces(DIMENSIONS, PANEL_BASE));
    }

    private void Start()
    {
        var parentAudio = transform.parent.GetComponent<AudioSource>();
        StartCoroutine(DelayPlayAudio(parentAudio));
    }

    private IEnumerator DelayPlayAudio(AudioSource audioSource)
    {
        yield return new WaitForSeconds(1.0f);
        Utilities.PlayAudio(audioSource);
        Timeout.SetRepeatAudio(audioSource);
        Timeout.StartTimers();
    }

    private List<GameObject> GenerateGridPanels(int dimensions, string panelBase)
    {
        var gridList = new List<GameObject>();
        int counter = 1;

        for (int y = 0; y < dimensions; ++y)
        {
            for (int x = 0; x < dimensions; ++x)
            {
                var gridPanel = (GameObject)Instantiate(gridPrefab);
                gridPanel.transform.parent = transform;
                gridPanel.name = panelBase + counter;

                var newWidth = MAX_WIDTH/dimensions;
                var newHeight = MAX_HEIGHT/dimensions;
                var scale = new Vector3(newWidth / MAX_WIDTH,
                    newHeight / MAX_HEIGHT);
                gridPanel.transform.localScale = scale;

                gridPanel.transform.localPosition = new Vector3(X_LOWER_BOUND + ((newWidth - 3) * x), Y_LOWER_BOUND + (y * (newHeight - 3)), 0);

                gridList.Add(gridPanel);
                ++counter;
            }
        }
        return gridList;
    }
}
