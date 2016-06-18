using UnityEngine;

namespace AngryScene
{
    public class AngryReset : InitOnReset
    {
        protected override void Start()
        {
            GUIInitialization.Initialize();
            base.Start();
        }
    }
}
