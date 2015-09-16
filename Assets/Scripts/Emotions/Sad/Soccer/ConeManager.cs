using System.Linq;
using UnityEngine;

namespace SadScene
{
    public class ConeManager : ObjectSequenceManager
    {
        [HideInInspector]
        public static Vector3 randomPosition;

        public float[] conePositions;
        public ParticleSystem[] lanes;

        private readonly Color CORRECT_LANE_COLOR = new Color(0, 255, 1);
        private readonly Color WRONG_LANE_COLOR = new Color(255, 0, 0);

        public void RandomizePositionZ()
        {
            var zPosition = conePositions[Random.Range(0, conePositions.Length)];
            var objectPosition = SequenceObjects[currentIndex].transform.position;
            var newPosition = new Vector3(objectPosition.x, objectPosition.y, zPosition);
            SequenceObjects[currentIndex].transform.position = randomPosition;
            randomPosition = newPosition;
            adjustLaneColors();
        }

        private void adjustLaneColors()
        {
            var positionIndex = conePositions.ToList().IndexOf(randomPosition.z);
            lanes.ToList().ForEach(lane =>
            {
                lane.Stop();
                lane.startColor = lanes.ToList().IndexOf(lane) == positionIndex ? CORRECT_LANE_COLOR : WRONG_LANE_COLOR;
            });
        }
    }
}
