using System.Linq;
using Globals;
using UnityEngine;

namespace ScaredScene
{
    // Initialization on scene reset for the Scared Scene
    public class ScaredReset : InitOnReset
    {
        public FearfulMovement mainCharacter;
        public GameObject[] parentCharacters;

        protected override void Start()
        {
            GUIInitialization.Initialize();
            if (GameFlags.AdultIsPresent)
            {
                parentCharacters.ToList()
                    .First(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()))
                    .transform.parent.gameObject
                    .SetActive(true);
            }
            mainCharacter.SetWaitingForScarlet(false);
            base.Start();
        }
    }
}
