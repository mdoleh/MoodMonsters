using System.Linq;
using Globals;
using UnityEngine;

namespace BlendsScene
{
    public class BlendsTutorial : TutorialBase
    {
        public GameObject[] childrenPairs;
        public GameObject[] parents;

        public override void InitializeGameObjects()
        {
            base.InitializeGameObjects();
            GameFlags.ParentGender = Random.Range(0, 2) == 0 ? "Mom" : "Dad";
            childrenPairs.ToList().Find(x => x.name.ToLower().Equals(GameFlags.PlayerGender.ToLower())).SetActive(true);
            parents.ToList().Find(x => x.name.ToLower().Equals(GameFlags.ParentGender)).SetActive(true);
        }
    }
}