using System.Collections;
using System.Linq;
using Globals;
using UnityEngine;

namespace ScaredScene
{
    public class FearfulMovementParentPayAttentionAskActionsMenu : FearfulMovementActionsMenu
    {
        protected override void Start()
        {
            base.Start();
            StartCoroutine(ShowActionsMenu("ParentPayAttentionAskCanvas" + GameFlags.ParentGender));
        }
    }
}