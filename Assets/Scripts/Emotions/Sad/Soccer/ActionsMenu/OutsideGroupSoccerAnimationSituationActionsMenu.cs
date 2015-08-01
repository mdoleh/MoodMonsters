namespace SadScene
{
    public class OutsideGroupSoccerAnimationSituationActionsMenu : OutsideGroupSoccerAnimationActionsMenu
    {
        protected override void Start()
        {
            base.Start();
            StartCoroutine(ShowActionsMenu("SituationActionsCanvas"));
        }
    }
}