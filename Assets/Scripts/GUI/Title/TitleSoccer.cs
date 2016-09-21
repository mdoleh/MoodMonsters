using SadScene;
using UnityEngine;

namespace TitleScreen
{
    // Used by the Title Screen models to kick the soccer ball back and forth
    // exists on the soccer ball itself
    public class TitleSoccer : GroupSoccerBallMovement
    {
        public override void KickBallForward(Vector3 direction)
        {
            NeutralizeForce();
            rigidBody.AddForce(direction*500f);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            var character = other.GetComponent<GroupSoccerAnimation>();
            if (character != null)
            {
                character.KickForward();
            }
        }
    }
}