﻿using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class ActionBase : MonoBehaviour
    {
        protected bool startTimer = false;
        protected bool eventTrigger = false;
        protected bool isCorrect = false;
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
                if (isCorrect) {
                    sceneReset.TriggerCorrect();
                } else {
                    sceneReset.TriggerSceneReset();
                }
                sceneResetting = true;
            }
        }
    }
}