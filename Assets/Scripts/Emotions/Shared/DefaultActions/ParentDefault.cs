using UnityEngine;
using System.Collections;
using System.Linq;
using Globals;

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