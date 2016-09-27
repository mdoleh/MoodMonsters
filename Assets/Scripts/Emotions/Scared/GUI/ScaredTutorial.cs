using System.Linq;
using Globals;
using UnityEngine;

namespace ScaredScene
{
    // Controls how the scene starts after the tutorial has played
    public class ScaredTutorial : TutorialBase
    {
        public GameObject scarlet;
        public GameObject aj;
        public GameObject[] parentCharacters;

        protected override void HelpExplanationComplete()
        {
            base.HelpExplanationComplete();
            if (GameFlags.AdultIsPresent)
            {
                parentCharacters.ToList()
                    .First(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()))
                    .transform.parent.gameObject
                    .SetActive(true);
            }
            scarlet.GetComponent<CharacterMovement>().StartSequence();
            aj.GetComponent<CharacterMovement>().StartSequence();
        }
    }
}