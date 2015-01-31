using UnityEngine;
using System.Collections;
using Globals;

namespace AngryScene
{
    public class ActionBase : MonoBehaviour
    {
        protected bool startTimer = false;
        protected bool eventTrigger = false;
        protected bool isCorrect = false;
        protected float timer = 0.0f;
        public SceneReset sceneReset;
        public AudioSource audioSource;
        bool sceneResetting = false;

        protected void Update()
        {
            if (startTimer)
            {
                timer += Time.deltaTime;
            }

            if (eventTrigger && timer > 5.0f && !sceneResetting)
            {
                if (isCorrect) {
                    sceneReset.TriggerCorrect(audioSource, Scenes.GetNextPuzzle());
                } else {
                    sceneReset.TriggerSceneReset(audioSource);
                }
                sceneResetting = true;
            }
        }
    }
}