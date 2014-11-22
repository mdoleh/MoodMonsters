using UnityEngine;
using System.Collections;

public class TakeItem : MonoBehaviour {

    GameObject iPad;
    GameObject[] GUI;

    public void Awake() {
        iPad = GameObject.FindGameObjectWithTag("iPad");
        GUI = GameObject.FindGameObjectsWithTag("GUI");
    }

    public void StartTakingItem() {
        iPad.transform.parent = transform;
        iPad.transform.localPosition = new Vector3(0.1f, 1.43f, 0.3f);
        iPad.transform.Rotate(new Vector3(344.1776f, 180f, 0f));

        StartGUI();
    }

    void StartGUI() {
        for (int ii = 0; ii < GUI.Length; ++ii)
        {
            if (GUI[ii].name == "EmotionsCanvas")
            {
                GUI[ii].GetComponent<Canvas>().enabled = true;
                return;
            }
        }
    }
}
