using UnityEngine;
using System.Collections;

namespace SadScene
{
    public class ParentDefault : MonoBehaviour
    {
        public GameObject parentCharacter;

        private bool triggered = false;

        private void Update()
        {
            if (GetComponent<Canvas>().enabled && !triggered)
            {
                parentCharacter.GetComponent<Comfort>().StartDefaultAction();
                triggered = true;
            }
        }
    }
}