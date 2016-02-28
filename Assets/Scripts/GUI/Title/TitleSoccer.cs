﻿using SadScene;
using UnityEngine;

namespace TitleScreen
{
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