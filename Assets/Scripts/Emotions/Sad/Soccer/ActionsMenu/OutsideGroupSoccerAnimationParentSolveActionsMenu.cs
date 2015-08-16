using System.Linq;
using Globals;
using UnityEngine;

namespace SadScene
{
    public class OutsideGroupSoccerAnimationParentSolveActionsMenu : OutsideGroupSoccerAnimationActionsMenu
    {
        public GameObject[] PASSLetters;

        protected override void Start()
        {
            base.Start();
            PASSLetters.ToList().ForEach(x => x.SetActive(true));
            StartCoroutine(ShowActionsMenu("ParentSolveCanvas" + GameFlags.ParentGender));
        }
    }
}