using SadScene;
using UnityEngine;

public class SadTutorial : TutorialBase
{
    public GameObject luis;
    public GroupSoccerBallMovement groupSoccerBall;

    protected override void HelpExplanationComplete()
    {
        base.HelpExplanationComplete();
        groupSoccerBall.RestartSoccerGame();
        luis.GetComponent<OutsideGroupSoccerAnimation>().KickForwardWithDelay();
    }
}