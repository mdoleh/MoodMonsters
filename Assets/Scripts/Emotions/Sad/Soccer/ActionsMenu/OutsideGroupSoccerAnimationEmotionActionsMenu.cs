namespace SadScene
{
    public class OutsideGroupSoccerAnimationEmotionActionsMenu : OutsideGroupSoccerAnimationActionsMenu
    {
        protected override void Start()
        {
            base.Start();
            StartCoroutine(ShowActionsMenu("EmotionActionsCanvas"));
        }
    }
}