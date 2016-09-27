using UnityEngine;

namespace HappyScene
{
    // Runs on every scene reset for the Happy Scene
    public class HappyReset : InitOnReset
    {
        protected override void Start()
        {
            GUIInitialization.Initialize();
            base.Start();
        }
    }
}
