using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {

    public ApproachPlayer AI;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToLower() == "player")
        {
            AI.StartApproach();
            
        }
    }
}
