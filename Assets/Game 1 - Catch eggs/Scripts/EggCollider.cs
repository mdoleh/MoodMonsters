using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

public class EggCollider : MonoBehaviour {

    PlayerScript myPlayerScript;
    public SceneReset sceneReset;
    public AudioSource goodSound;
    public AudioSource badSound;
    private string lastSceneCompleted;
    private const string PREFAB_NAME_BASE = "EggPrefab";

    //Automatically run when a scene starts
    void Awake()
    {
        myPlayerScript = transform.parent.GetComponent<PlayerScript>();
        lastSceneCompleted = Scenes.GetLastSceneCompleted();
    }

    //Triggered by Unity's Physics
	void OnTriggerEnter(Collider theCollision)
    {
        //In this game we don't need to check *what* we hit; it must be the eggs
        Transform collisionGO = theCollision.transform;
	    StartCoroutine(HandleCollision(collisionGO));
    }

    private IEnumerator HandleCollision(Transform egg)
    {
        AdjustScore(egg);
        Destroy(egg.parent.gameObject);
        if (myPlayerScript.theScore >= 5)
        {
            yield return new WaitForSeconds(goodSound.clip.length);
            sceneReset.TriggerCorrect(audio, Scenes.GetNextMiniGame());
        }
    }

    private void AdjustScore(Transform egg)
    {
        var emotion = egg.parent.gameObject.name.Replace(PREFAB_NAME_BASE, "");
        emotion = emotion.Replace("(Clone)", "");
        if (lastSceneCompleted.Contains(emotion))
        {
            myPlayerScript.UpdateScore(1);
            Utilities.PlayAudio(goodSound);
        }
        else
        {
            myPlayerScript.UpdateScore(-1);
            Utilities.PlayAudio(badSound);
        }
        if (myPlayerScript.theScore < 0) myPlayerScript.theScore = 0;
    }
}
