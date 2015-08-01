namespace SadScene
{
    public class OutsideGroupSoccerAnimationParentActionsMenu : OutsideGroupSoccerAnimationActionsMenu
    {
        protected override void Start()
        {
            base.Start();
            StartCoroutine(ShowActionsMenu("ParentActionsCanvas"));
        }
    }
}