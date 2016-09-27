using System.Linq;
using Globals;
using SadScene;
using UnityEngine;

// Controls how the scene should start after the tutorial has played
public class SadTutorial : TutorialBase
{
    public GameObject luis;
    public GroupSoccerBallMovement groupSoccerBall;
    public AudioSource[] intros;
    public Transform[] parents;

    protected override void Start()
    {
        base.Start();
        var currentParent = parents.ToList().Find(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()));
        currentParent.position = new Vector3(171.3429f, 3.9f, 82.87959f);
        currentParent.rotation = Quaternion.Euler(new Vector3(0f, 155.3385f, 0f));
        currentParent.gameObject.SetActive(true);
    }

    protected override void HelpExplanationComplete()
    {
        base.HelpExplanationComplete();
        groupSoccerBall.RestartSoccerGame();
        luis.GetComponent<OutsideGroupSoccerAnimation>().KickForwardWithDelay();
    }

    protected override void InitializeAudio()
    {
        base.InitializeAudio();
        introAudio = intros.ToList().Find(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()));
    }
}