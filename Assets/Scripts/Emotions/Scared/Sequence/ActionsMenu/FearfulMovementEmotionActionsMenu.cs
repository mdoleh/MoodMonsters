namespace ScaredScene
{
    public class FearfulMovementEmotionActionsMenu : FearfulMovementActionsMenu
    {
        protected override void Start()
        {
            base.Start();
            StartCoroutine(ShowActionsMenu("EmotionActionsCanvas"));
        }
    }
}