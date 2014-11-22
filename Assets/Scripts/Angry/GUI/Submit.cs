using UnityEngine;
using System.Collections;

public class Submit : MonoBehaviour {

    GameObject[] GUI;

    void Awake() {
        GUI = GameObject.FindGameObjectsWithTag("GUI");
    }

    public void SubmitResponse() {
        Debug.Log("Submit click");

        StartGUI();
    }

    void StartGUI()
    {
        for (int ii = 0; ii < GUI.Length; ++ii)
        {
            if (GUI[ii].name == "ActionsCanvas")
            {
                GUI[ii].GetComponent<Canvas>().enabled = true;
            }
            if (GUI[ii].name == "PhysicalCanvas")
            {
                GUI[ii].GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
