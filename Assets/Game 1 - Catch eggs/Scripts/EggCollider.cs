using UnityEngine;
using System.Collections;
using System.Linq;

public class EggCollider : MonoBehaviour {

    PlayerScript myPlayerScript;
    private string lastSceneCompleted;
    private const string PREFAB_NAME_BASE = "EggPrefab";

    //Automatically run when a scene starts
    void Awake()
    {
        myPlayerScript = transform.parent.GetComponent<PlayerScript>();
        lastSceneCompleted = Globals.Scenes.CompletedScenes.Last();
    }

    //Triggered by Unity's Physics
	void OnTriggerEnter(Collider theCollision)
    {
        //In this game we don't need to check *what* we hit; it must be the eggs
        Transform collisionGO = theCollision.transform;
	    AdjustScore(collisionGO);
        Destroy(collisionGO.parent.gameObject);
    }

    private void AdjustScore(Transform egg)
    {
        var emotion = egg.parent.gameObject.name.Replace(PREFAB_NAME_BASE, "");
        emotion = emotion.Replace("(Clone)", "");
        if (lastSceneCompleted.Contains(emotion))
        {
            ++myPlayerScript.theScore;
        }
        else
        {
            --myPlayerScript.theScore;
        }
        if (myPlayerScript.theScore < 0) myPlayerScript.theScore = 0;
    }
}
