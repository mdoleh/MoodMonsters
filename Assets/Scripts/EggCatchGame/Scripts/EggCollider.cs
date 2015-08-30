using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

namespace EggCatch
{
    public class EggCollider : MonoBehaviour
    {

        private PlayerScript myPlayerScript;
        public SceneReset sceneReset;
        public AudioSource goodSound;
        public AudioSource badSound;
        private string lastSceneCompleted;
        private const string PREFAB_NAME_BASE = "EggPrefab";

        //Automatically run when a scene starts
        private void Awake()
        {
            myPlayerScript = transform.parent.GetComponent<PlayerScript>();
            lastSceneCompleted = Scenes.GetLastSceneCompleted();
        }

        //Triggered by Unity's Physics
        private void OnTriggerEnter(Collider theCollision)
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
                sceneReset.TriggerCorrect(GetComponent<AudioSource>(), Scenes.GetNextMiniGame(), true);
            }
        }

        private void AdjustScore(Transform egg)
        {
            // should only be false on the Angry Scene
            // want the other sounds to play over this one
            if (!myPlayerScript.shouldKeepScore)
            {
                Utilities.PlayAudioUnBlockable(goodSound);
                return;
            }

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
}