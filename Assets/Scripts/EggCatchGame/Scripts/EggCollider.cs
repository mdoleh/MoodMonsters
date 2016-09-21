using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

namespace EggCatch
{
    // Updates the player's score when an egg is caught in the bucket
    public class EggCollider : MonoBehaviour
    {
        private PlayerScript myPlayerScript;
        public SceneReset sceneReset;
        public AudioSource goodSound;
        public AudioSource badSound;
        public AudioSource[] reminders;
        private string lastSceneCompleted;
        private AudioSource reminderToPlay;
        private bool loadingNextScene = false;
        private const string PREFAB_NAME_BASE = "EggPrefab";
        
        private void Awake()
        {
            myPlayerScript = transform.parent.GetComponent<PlayerScript>();
            lastSceneCompleted = Scenes.GetLastEmotionCompleted();
            reminderToPlay = reminders.ToList().FirstOrDefault(x => lastSceneCompleted.Contains(x.gameObject.name));
        }
        
        private void OnTriggerEnter(Collider theCollision)
        {
            Transform collisionGO = theCollision.transform;
            StartCoroutine(HandleCollision(collisionGO));
        }

        private IEnumerator HandleCollision(Transform egg)
        {
            yield return StartCoroutine(AdjustScore(egg));
            if (myPlayerScript.theScore == myPlayerScript.MAX_SCORE && !loadingNextScene)
            {
                yield return new WaitForSeconds(goodSound.clip.length);
                sceneReset.TriggerCorrect(GetComponent<AudioSource>(), Scenes.GetNextMiniGame(), true);
                loadingNextScene = true;
            }
            if (egg != null && egg.parent != null)
                Destroy(egg.parent.gameObject);
        }

        protected virtual IEnumerator AdjustScore(Transform egg)
        {
            if (loadingNextScene) yield break;

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
                yield return new WaitForSeconds(badSound.clip.length);
                Utilities.PlayAudio(reminderToPlay);
            }
            if (myPlayerScript.theScore < 0) myPlayerScript.theScore = 0;
        }
    }
}