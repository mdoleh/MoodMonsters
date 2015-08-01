using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

namespace SadScene
{
    public class ParentDefault : MonoBehaviour
    {
        public GameObject[] parentCharacters;

        private bool triggered = false;
        private GameObject currentParent;

        private void Start()
        {
            currentParent = parentCharacters.ToList().First(x => x.name.ToLower().Contains(GameFlags.ParentGender.ToLower()));
        }

        private void Update()
        {
            if (GetComponent<Canvas>().enabled && !triggered)
            {
                currentParent.GetComponent<Comfort>().StartDefaultAction();
                triggered = true;
            }
        }
    }
}