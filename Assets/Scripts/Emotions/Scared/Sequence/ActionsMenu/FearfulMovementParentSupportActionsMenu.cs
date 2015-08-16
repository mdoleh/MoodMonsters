using System.Collections;
using System.Linq;
using Globals;
using UnityEngine;

namespace ScaredScene
{
    public class FearfulMovementParentSupportActionsMenu : FearfulMovementActionsMenu
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