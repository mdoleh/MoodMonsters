namespace ScaredScene
{
    public class FearfulMovementSituationActionsMenu : FearfulMovementActionsMenu
    {
        protected override void Start()
        {
            base.Start();
            StartCoroutine(ShowActionsMenu("SituationActionsCanvas"));
        }
    }
}