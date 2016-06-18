using System;
using System.Collections.Generic;
using System.Linq;
using Globals;
using UnityEngine;

public class GUIInitialization : MonoBehaviour
{
    public static void Initialize()
    {
        var canvasList = GameObject.Find("CanvasList").GetComponent<CanvasList>();
        var list = canvasList.Canvases.ToList();

        Predicate<GameObject> filter;
        if (GameFlags.AdultIsPresent)
        {
            filter = x => x.name.Contains("Parent") && !x.name.Contains(GameFlags.ParentGender);
        }
        else
        {
            filter = x => x.name.Contains("Parent") && !x.name.Contains("ParentDefault");
        }
        cleanupHierarchy(list, filter);

        if (!string.IsNullOrEmpty(GameFlags.PlayerGender))
        {
            filter = x => x.name.Contains("Actions") && !x.name.Contains(GameFlags.PlayerGender);
        }
        cleanupHierarchy(list, filter);

        canvasList.Canvases = list.ToArray();

        GUIHelper.Canvases = canvasList.gameObject;
    }

    private static void cleanupHierarchy(List<GameObject> list, Predicate<GameObject> filter)
    {
        var toRemove = list.FindAll(filter);
        list.RemoveAll(filter);
        toRemove.ForEach(Destroy);
    }
}
