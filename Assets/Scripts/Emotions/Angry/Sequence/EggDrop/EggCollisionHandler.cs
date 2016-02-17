using UnityEngine;
using System.Collections;

namespace AngryScene
{
    public class EggCollisionHandler : EggCatch.EggCollider
    {
        protected override IEnumerator AdjustScore(Transform egg)
        {
            Utilities.PlayAudioUnBlockable(goodSound);
            yield break;
        }
    }
}