using UnityEngine;
using System.Collections;

namespace AngryScene
{
    // Customized behavior for the Angry Scene
    // Want the same sound to play for all eggs
    public class EggCollisionHandler : EggCatch.EggCollider
    {
        protected override IEnumerator AdjustScore(Transform egg)
        {
            Utilities.PlayAudioUnBlockable(goodSound);
            yield break;
        }
    }
}