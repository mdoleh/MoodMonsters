using System.Linq;
using Globals;
using UnityEngine;

namespace SadScene
{
    public class OutsideGroupSoccerAnimationParentSupportActionsMenu : OutsideGroupSoccerAnimationActionsMenu
    {
        public GameObject[] PASSLetters;

        protected override void Start()
        {
            base.Start();
            PASSLetters.ToList().ForEach(x => x.SetActive(true));
            StartCoroutine(ShowActionsMenu("ParentSupportCanvas" + GameFlags.ParentGender));
        }
    }
}