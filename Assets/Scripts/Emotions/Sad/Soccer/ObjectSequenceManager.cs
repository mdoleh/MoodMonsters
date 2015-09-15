using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class ObjectSequenceManager : MonoBehaviour
    {
        public GameObject[] SequenceObjects;
        public int currentIndex = 0;

        public virtual void NextInSequence()
        {
            if (currentIndex >= SequenceObjects.Length) return;
            SequenceObjects[currentIndex++].SetActive(true);
        }

        public void RandomizePositionZ(float min, float max)
        {
            var newPosition = Random.Range(min, max);
            var objectPosition = SequenceObjects[currentIndex].transform.position;
            SequenceObjects[currentIndex].transform.position = new Vector3(objectPosition.x, objectPosition.y, newPosition);
        }
    }
}
