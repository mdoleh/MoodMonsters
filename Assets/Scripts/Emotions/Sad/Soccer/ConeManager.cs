using System.Linq;
using UnityEngine;

namespace SadScene
{
    public class ConeManager : ObjectSequenceManager
    {
        public float[] conePositions;
        public ParticleSystem[] lanes;

        private readonly Color CORRECT_LANE_COLOR = new Color(0, 255, 0);
        private readonly Color WRONG_LANE_COLOR = new Color(255, 0, 0);

        public float RandomizePositionZ()
        {
            if (currentIndex >= SequenceObjects.Length)
            {
                // middle lane is the correct lane for the final cone
                adjustLaneColors(conePositions[1]);
                return 80.52f;
            }
            var index = Random.Range(0, conePositions.Length);
            var objectPosition = SequenceObjects[currentIndex - 1].transform.localPosition;
            SequenceObjects[currentIndex - 1].transform.localPosition = new Vector3(objectPosition.x, objectPosition.y, conePositions[index]);
            adjustLaneColors(conePositions[index]);
            return SequenceObjects[currentIndex - 1].transform.position.z;
        }

        private void adjustLaneColors(float zPosition)
        {
            var positionIndex = conePositions.ToList().IndexOf(zPosition);
            lanes.ToList().ForEach(lane =>
            {
                lane.Stop();
                lane.startColor = lanes.ToList().IndexOf(lane) == positionIndex ? CORRECT_LANE_COLOR : WRONG_LANE_COLOR;
            });
            LaneAppear.shouldShowLanes = true;
        }
    }
}
