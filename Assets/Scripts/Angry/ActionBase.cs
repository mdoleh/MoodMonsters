using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class ActionBase : MonoBehaviour
    {
        protected bool startTimer = false;
        protected bool eventTrigger = false;
        protected float timer = 0.0f;
        public SceneReset sceneReset;
        bool sceneResetting = false;

        protected void Update()
        {
            if (startTimer)
            {
                timer += Time.deltaTime;
            }

            if (eventTrigger && timer > 5.0f && !sceneResetting)
            {
                sceneReset.TriggerSceneReset();
                sceneResetting = true;
            }
        }
    }
}