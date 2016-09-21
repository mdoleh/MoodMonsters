using System;
using System.Collections.Generic;
using System.Linq;
using Globals;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIInitialization : MonoBehaviour
{
    public static void Initialize()
    {
        var canvasList = GameObject.Find("CanvasList").GetComponent<CanvasList>();
        var list = canvasList.Canvases.ToList();

        // determine which Parent canvases to filter out
        // based on whether or not an adult is present
        Predicate<GameObject> filter;
        if (GameFlags.AdultIsPresent)
        {
            filter = x => x.name.Contains("Parent") && !x.name.Contains(GameFlags.ParentGender);
        }
        else
        {
            if (string.IsNullOrEmpty(GameFlags.ParentGender))
                GameFlags.ParentGender = new List<string> {"Mom", "Dad"}[UnityEngine.Random.Range(0, 2)];
            filter = x => x.name.Contains("Parent") && !x.name.Contains("ParentDefault");
        }
        cleanupHierarchy(list, filter);

        // filter questions based on player gender if one was provided
        // player gender is only provided in the Blends Scene
        if (!string.IsNullOrEmpty(GameFlags.PlayerGender))
        {
            filter = x => x.name.Contains("Actions") && !x.name.Contains(GameFlags.PlayerGender);
        }
        cleanupHierarchy(list, filter);

        canvasList.Canvases = list.ToArray();

        GUIHelper.Canvases = canvasList.gameObject;
        initializeIndexFromDebugTools(list);
    }

    private static void cleanupHierarchy(List<GameObject> list, Predicate<GameObject> filter)
    {
        var toRemove = list.FindAll(filter);
        list.RemoveAll(filter);
        toRemove.ForEach(Destroy);
    }

    private static void initializeIndexFromDebugTools(List<GameObject> canvases)
    {
        if (string.IsNullOrEmpty(SceneLoader.DebugCanvasToLoad)) return;
        // must have loaded an 'actions' scene for this to be used
        if (!SceneManager.GetActiveScene().name.Contains("Actions")) return;
        var index = canvases.FindIndex(x => x.name.Contains(SceneLoader.DebugCanvasToLoad));
        if (index == -1 && SceneLoader.DebugCanvasToLoad.Contains("Parent"))
        {
            index = canvases.FindIndex(x => x.name.Contains("Parent"));
        }
        if (index == -1) return;
        CanvasList.SetIndex(index);
    }
}
