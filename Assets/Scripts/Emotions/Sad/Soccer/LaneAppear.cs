using UnityEngine;
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
        GameObject.Find("Lanes").GetComponentsInChildren<ParticleSystem>().ToList().ForEach(lane => lane.Stop());
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
            transform.parent.GetComponent<ParticleSystem>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<OutsideGroupSoccerAnimation>() != null && shouldShowLanes)
        {
            transform.parent.GetComponent<ParticleSystem>().Stop();
        }
    }

    private void Update()
    {
        if (isIntersectingPlayer && shouldShowLanes)
        {
            isIntersectingPlayer = false;
            transform.parent.GetComponent<ParticleSystem>().Play();
        }
    }
}
