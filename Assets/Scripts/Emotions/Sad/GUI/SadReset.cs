using UnityEngine;

namespace SadScene
{
    // Triggered on every Sad Scene reset
    public class SadReset : InitOnReset
    {
        public CharacterMovement mainCharacter;

        protected override void Start()
        {
            GUIInitialization.Initialize();
            mainCharacter.EnableParent();
            mainCharacter.GetComponent<CapsuleCollider>().enabled = false;
            base.Start();
        }
    }
}
