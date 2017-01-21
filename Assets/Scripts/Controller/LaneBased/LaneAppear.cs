using System.Linq;
using UnityEngine;

public class LaneAppear<T> : MonoBehaviour
{
    [HideInInspector] public static bool shouldShowLanes;

    private bool isIntersectingPlayer;

    public static void HideAllLanes()
    {
        var lanes = GameObject.Find("Lanes");
        if (lanes != null) lanes
            .GetComponentsInChildren<LaneColor>()
            .ToList()
            .ForEach(lane => lane.GetComponent<MeshRenderer>().enabled = false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<T>() != null)
        {
            if (!shouldShowLanes)
            {
                return;
            }
            HideAllLanes();
            transform.parent.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<T>() != null)
        {
            if (!shouldShowLanes)
            {
                return;
            }
            transform.parent.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}