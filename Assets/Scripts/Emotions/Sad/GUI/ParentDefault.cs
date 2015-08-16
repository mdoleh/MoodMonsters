using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

namespace SadScene
{
    public class ParentDefault : MonoBehaviour
    {
        public GameObject[] parentCharacters;

        private bool askTriggered = false;
        private GameObject currentParent;

        private void Start()
        {
            currentParent = parentCharacters.ToList().First(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()));
        }

        private void Update()
        {
            if (GetComponent<Canvas>().enabled && !askTriggered)
            {
                currentParent.GetComponent<Ask>().StartDefaultAction();
                askTriggered = true;
            }
        }
    }
}