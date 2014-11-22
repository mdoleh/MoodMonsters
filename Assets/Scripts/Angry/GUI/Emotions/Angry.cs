using UnityEngine;
using System.Collections;

public class Angry : MonoBehaviour {

    GameObject[] GUI;

    void Awake()
    {
        GUI = GameObject.FindGameObjectsWithTag("GUI");
    }

    public void ClickTest()
    {
        Debug.Log("Angry click");

        StartGUI();
    }

    void StartGUI()
    {
        for (int ii = 0; ii < GUI.Length; ++ii)
        {
            if (GUI[ii].name == "PhysicalCanvas")
            {
                GUI[ii].GetComponent<Canvas>().enabled = true;
            }
            if (GUI[ii].name == "EmotionsCanvas")
            {
                GUI[ii].GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
