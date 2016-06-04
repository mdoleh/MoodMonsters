﻿using System.Linq;
using Globals;
using UnityEngine;

public class GUIInitialization : MonoBehaviour
{
    public static void Initialize()
    {
        var canvasList = GameObject.Find("CanvasList").GetComponent<CanvasList>();
        var list = canvasList.Canvases.ToList();

        if (GameFlags.AdultIsPresent)
        {
            list.RemoveAll(x => x.name.Contains("Parent") && !x.name.Contains(GameFlags.ParentGender));
        }
        else
        {
            list.RemoveAll(x => x.name.Contains("Parent") && !x.name.Contains("ParentDefault"));
        }

        if (!string.IsNullOrEmpty(GameFlags.PlayerGender))
        {
            list.RemoveAll(x => x.name.Contains("Actions") && !x.name.Contains(GameFlags.PlayerGender));
        }

        canvasList.Canvases = list.ToArray();

        GUIHelper.Canvases = canvasList.gameObject;
    }
}
