﻿using UnityEngine;

namespace AngryScene
{
    // Runs on every scene reset for the Angry Scene
    public class AngryReset : InitOnReset
    {
        protected override void Start()
        {
            GUIInitialization.Initialize();
            base.Start();
        }
    }
}
