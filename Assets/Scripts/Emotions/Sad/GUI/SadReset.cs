using UnityEngine;

namespace SadScene
{
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
