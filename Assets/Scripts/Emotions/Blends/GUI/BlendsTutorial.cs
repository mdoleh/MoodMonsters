using System.Linq;
using Globals;
using UnityEngine;

namespace BlendsScene
{
    public class BlendsTutorial : TutorialBase
    {
        public GameObject[] childrenPairs;
        public GameObject[] parents;
        public AudioSource[] introAudioClips;

        public override void InitializeGameObjects()
        {
            GameFlags.ParentGender = Random.Range(0, 2) == 0 ? "Mom" : "Dad";
            childrenPairs.ToList().Find(x => x.name.ToLower().Contains(GameFlags.PlayerGender.ToLower())).SetActive(true);
            parents.ToList().Find(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower())).SetActive(true);
        }

        protected override void InitializeAudio()
        {
            introAudio = introAudioClips.ToList()
                .Find(x => x.gameObject.name.ToLower().Contains(GameFlags.PlayerGender.ToLower()));
        }
    }
}