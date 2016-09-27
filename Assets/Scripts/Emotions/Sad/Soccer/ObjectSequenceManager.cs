using UnityEngine;

namespace SadScene
{
    // Generic script for handling sequences of objects that need to show one after another
    // ex: Cones, Miss points
    public class ObjectSequenceManager : MonoBehaviour
    {
        public GameObject[] SequenceObjects;
        public int currentIndex = 0;

        public virtual void NextInSequence()
        {
            if (currentIndex >= SequenceObjects.Length) return;
            SequenceObjects[currentIndex++].SetActive(true);
        }
    }
}
