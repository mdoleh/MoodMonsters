using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

// Generic class to trigger Parent Default actions when the canvas is triggered
// Used for triggering Parent dialogue automatically when an adult is not present
// Each scene overrides this class and applies their script type
public class ParentDefault<T> : MonoBehaviour where T : DefaultActionBase
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
        if (!triggered)
        {
            currentParent.GetComponent<T>().StartDefaultAction();
            triggered = true;
        }
    }
}