using Globals;

namespace SadScene
{
    public class OutsideGroupSoccerAnimationParentPayAttentionAskActionsMenu : OutsideGroupSoccerAnimationActionsMenu
    {
        protected override void Start()
        {
            base.Start();
            StartCoroutine(ShowActionsMenu("ParentPayAttentionAskCanvas" + GameFlags.ParentGender));
        }
    }
}