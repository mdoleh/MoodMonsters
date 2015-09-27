﻿using UnityEngine;
using System.Collections;
using System.Linq;
using SadScene;

public class LaneAppear : MonoBehaviour
{
    [HideInInspector] 
    public static bool shouldShowLanes;

    private bool isIntersectingPlayer;

    public static void HideAllLanes()
    {
        GameObject.Find("Lanes").GetComponentsInChildren<LaneColor>().ToList().ForEach(lane => lane.GetComponent<MeshRenderer>().enabled = false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<OutsideGroupSoccerAnimation>() != null)
        {
            if (!shouldShowLanes)
            {
                isIntersectingPlayer = true;
                return;
            }
            transform.parent.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<OutsideGroupSoccerAnimation>() != null && shouldShowLanes)
        {
            transform.parent.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void Update()
    {
        if (isIntersectingPlayer && shouldShowLanes)
        {
            isIntersectingPlayer = false;
            transform.parent.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
