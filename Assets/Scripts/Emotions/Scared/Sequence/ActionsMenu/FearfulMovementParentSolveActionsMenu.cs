using System.Collections;
using System.Linq;
using Globals;
using UnityEngine;

namespace ScaredScene
{
    public class FearfulMovementParentSolveActionsMenu : FearfulMovementActionsMenu
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